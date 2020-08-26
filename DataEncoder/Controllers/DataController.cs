using EncryptorLOGIC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataEncryptor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private IEncryptorService _encryptorService;
        public DataController(IEncryptorService encryptorService)
        {
            _encryptorService = encryptorService;
        }

    }
}
