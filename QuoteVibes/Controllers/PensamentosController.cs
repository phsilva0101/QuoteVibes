using Microsoft.AspNetCore.Mvc;
using QuoteVibes.Domain.Base;
using QuoteVibes.Domain.Interface.Pensamento;
using QuoteVibes.Domain.ViewModels.Pensamento;
using QuoteVibes.Domain.ViewModels.Pensamento.Response;

namespace QuoteVibes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PensamentosController : ControllerBase
    {

        private readonly ILogger<PensamentosController> _logger;
        private readonly IPensamentosRepository _pensamentosRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PensamentosController(ILogger<PensamentosController> logger,
            IPensamentosRepository pensamentosRepository,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _pensamentosRepository = pensamentosRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetThoughts()
        {
            var entidades = await _pensamentosRepository.GetAllAsync();
            if (entidades != null && entidades.Any())
                return Ok(entidades.ToMapModel());

            return Ok(new List<PensamentoModel>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetThought(Guid id)
        {
            var entidade = await _pensamentosRepository.GetAsync(id);
            if (entidade != null)
                return Ok(entidade.ToMapModel());

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostThought(PensamentosInsertViewModel model)
        {
            var entidade = await _pensamentosRepository.AddAsync(model.ToEntity());

            if (entidade == null)
                return BadRequest("Ocorreu um erro ao inserir");

            await _unitOfWork.CommitarTransacaoAsync();
            return CreatedAtAction(nameof(GetThought), new { id = entidade.Id }, entidade.ToMapModel());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutThought(Guid id, PensamentoModel model)
        {
            var entidade = await _pensamentosRepository.GetAsync(id);
            if (entidade == null)
                return NotFound();

            entidade.Autor = model.Autor;
            entidade.Conteudo = model.Conteudo;
            entidade.Modelo = model.Modelo;
            entidade.DataAtualizacao = DateTime.Now;

            _pensamentosRepository.Update(entidade);
            await _unitOfWork.CommitarTransacaoAsync();
            return NoContent();
        }
    }
}