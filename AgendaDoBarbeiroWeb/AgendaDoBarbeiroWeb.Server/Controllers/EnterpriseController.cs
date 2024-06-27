
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDoBarbeiroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : Controller
    {
        private readonly IEnterpriseService _enterpriseService;
        private readonly IMapper _mapper;

        EnterpriseController(IMapper mapper, IEnterpriseService enterpriseService
            ,IProfessionalService professionalService)
        {
            _mapper = mapper;
            _enterpriseService = enterpriseService;
        }

        /// <summary>
        /// Gets a list of all enterprises.
        /// </summary>
        /// <returns>A list of enterprises.</returns>
        [HttpGet("list")]
        public ActionResult<List<EnterpriseDto>> List()
        {
            var enterprises = _enterpriseService.GetAll();
            return Ok(_mapper.Map<List<EnterpriseDto>>(enterprises));
        }

        // GET: EnterpriseController/Details/5
        [HttpGet("get/{id}")]
        public ActionResult<EnterpriseDto> Details(int id)
        {
            var enterprise = _enterpriseService.Get(id);
            return Ok(_mapper.Map<EnterpriseDto>(enterprise));
        }


        // POST: EnterpriseController/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnterpriseDto collection)
        {
            try
            {
                var enterprise = _mapper.Map<Enterprise>(collection);
                _enterpriseService.Create(enterprise);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }



        // POST: EnterpriseController/Edit/5
        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EnterpriseDto collection)
        {
            try
            {
                var enterprise = _mapper.Map<Enterprise>(collection);
                enterprise.EnterpriseId = id;
                _enterpriseService.Update(enterprise);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }


        // POST: EnterpriseController/Delete/5
        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EnterpriseDto collection)
        {
            try
            {
                var enterprise = _mapper.Map<Enterprise>(collection);
                enterprise.EnterpriseId = id;
                _enterpriseService.Delete(enterprise);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/professionals")]

        public ActionResult<EnterpriseDto> GetAllProfessionals(int id)
        {
            var enterprise = _enterpriseService.Get(id);
            return Ok(_mapper.Map<EnterpriseDto>(enterprise));
        }

    }
}
