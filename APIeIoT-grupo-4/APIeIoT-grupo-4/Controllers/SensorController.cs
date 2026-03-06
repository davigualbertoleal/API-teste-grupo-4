using Microsoft.AspNetCore.Mvc;

namespace APIeloT_grupo_4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    // Criamos uma lista estática para os dados não sumirem entre um envio e outro
    private static List<object> _historicoDados = new List<object>();

    // ROTA: POST api/Sensor
    // Usada pelo ESP32 (Wokwi) para enviar dados
    [HttpPost]
    public IActionResult ReceberDados([FromBody] object dados)
    {
        _historicoDados.Add(dados);

        Console.WriteLine($"[WOKWI LOG] -> {dados}");

        return Ok(new
        {
            mensagem = "deu bom, porra",
            horario = DateTime.Now.ToLongTimeString()
        });
    }

    [HttpGet]
    public IActionResult ListarDados()
    {
        return Ok(new
        {
            totalRecebido = _historicoDados.Count,
            dados = _historicoDados
        });
    }

    [HttpDelete]
    public IActionResult LimparHistorico()
    {
        _historicoDados.Clear();
        return Ok(new { mensagem = "historico resetado, porra" });
    }
}