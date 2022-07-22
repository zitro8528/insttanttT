using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insttantt.Context;
using Insttantt.Models;
using Insttantt.ViewModels;
using System.Reflection;

namespace Insttantt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FlowsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Flows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flow>>> GetFlows()
        {
            if (_context.Flows == null)
            {
                return NotFound();
            }
            return await _context.Flows.ToListAsync();
        }

        // GET: api/Flows/5
        [HttpGet("GetFlowSteps/{id}")]
        public async Task<ActionResult<IEnumerable<StepsViewModel>>> GetFlowSteps(Guid id)
        {
            if (_context.Flows == null)
            {
                return NotFound();
            }
            var flowSteps = _context.FlowConfigs
                .Where(x => x.FlowId.Equals(id))
                .Include(x => x.Flow)
                .Include(x => x.StepsCatalog)
                .Select(x => new StepsViewModel()
                {
                    StepName = x.StepsCatalog.Name,
                    Target = x.StepsCatalog.Target,
                    Level = x.Level
                })
                .OrderBy(x => x.Level)
                .ToList();

            if (flowSteps == null)
            {
                return NotFound();
            }

            return flowSteps;
        }

        // GET: api/Flows/5
        [HttpGet("StartFlow/{flowId}/{userId}")]
        public async Task<ActionResult<string>> StartFlow(Guid flowId, Guid userId)
        {
            var flowSteps = _context.FlowConfigs
                .Where(x => x.FlowId.Equals(flowId))
                .Include(x => x.Flow)
                .Include(x => x.StepsCatalog)
                .Select(x => new StepsViewModel()
                {
                    StepName = x.StepsCatalog.Name,
                    Target = x.StepsCatalog.Target,
                    Level = x.Level
                })
                .OrderBy(x => x.Level)
                .ToList();

            var userFields = _context.UserFields
                .Where(x => x.UserId.Equals(userId))
                .Select(x => new UserField()
                {
                    FielsCatalogId = x.FielsCatalogId,
                    Value = x.Value
                })
                .ToList();


            foreach (var step in flowSteps)
            {
                Console.WriteLine(step.StepName +" --- "+step.Level);
                await RunStepTarget(step.Target,userFields);
            }

            return Ok();
        }

        private Task<string> RunStepTarget(string target, List<UserField> userFields)
        {
            try
            {
                var routeResult = GetStepTarget(target);
                return (Task<string>)routeResult.methodInfo.Invoke(routeResult.classInstance, new object[] { userFields});
            }
            catch
            {
                throw;
            }

        }

        private (MethodInfo methodInfo, object classInstance) GetStepTarget(string target)
        {
            Type uploaderDocumentsType = Type.GetType(target);
            object classInstance = Activator.CreateInstance(uploaderDocumentsType, null);
            MethodInfo methodInfo = uploaderDocumentsType.GetMethod("RunStep");

            return (methodInfo, classInstance);
        }
    }
}
