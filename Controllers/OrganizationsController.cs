using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Organizations.DataTransfer;
using Organizations.Model;
using Organizations.Model.Operations;
using Organizations.Services;

namespace Organizations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class OrganizationsController : Controller
    {
        private readonly ILogger<OrganizationsController> _logger;
        private readonly IOrganizationsService _organizationsService;

        public OrganizationsController(
            ILogger<OrganizationsController> logger,
            IOrganizationsService organizationsService)
        {
            _logger = logger;
            _organizationsService = organizationsService;
        }

        /// <summary>
        ///     Возвращает все данные по всем организациям
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<IEnumerable<OrganizationFullDto>> GetOrganizations()
        {
            return _organizationsService.GetAllAsync();
        }

        /// <summary>
        ///     Возвращает изображение организации
        /// </summary>
        /// <param name="imageGuid">Guid изображения</param>
        [HttpGet("image/{imageGuid:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetImage(Guid imageGuid)
        {
            if (!await _organizationsService.CheckIfImageGuidExists(imageGuid))
                return NotFound(imageGuid);
            return File(await _organizationsService.GetImageAsync(imageGuid), "image/png");
        }

        /// <summary>
        ///     Возвращает логотип организации
        /// </summary>
        /// <param name="imageGuid">Guid изображения</param>
        [HttpGet("logo/{logoGuid:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLogo(Guid logoGuid)
        {
            if (!await _organizationsService.CheckIfLogoGuidExists(logoGuid))
                return NotFound(logoGuid);
            return File(await _organizationsService.GetLogoAsync(logoGuid), "image/png");
        }

        /// <summary>
        ///     Возвращает все данные по указанной организации
        /// </summary>
        [HttpGet("{guid:guid}")]
        public Task<OrganizationFullDto> GetOrganization(Guid guid)
        {
            return _organizationsService.GetByGuidAsync(guid);
        }

        /// <summary>
        ///     Регистрирует организацию в системе
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> Register(RegisterOrganizationDto registerOrganizationDto)
        {
            var logo = registerOrganizationDto.Logo;
            var images = registerOrganizationDto.Images;
            var contacts = registerOrganizationDto.Contacts;
            return Created(string.Empty, await _organizationsService.RegisterOrganizationAsync(
                await Organization.NewAsync(CreateOrganization.New(
                    OrganizationType.GetById(registerOrganizationDto.OrganizationTypeId),
                    new CreateOrUpdateContacts(
                        contacts.ActualAddress,
                        contacts.ActualGeoPosition,
                        contacts.PhoneNumber,
                        contacts.Email,
                        contacts.Site,
                        contacts.Telegram,
                        contacts.Instagram,
                        contacts.Vk),
                    registerOrganizationDto.LegalName,
                    registerOrganizationDto.LegalAddress,
                    registerOrganizationDto.ActualName,
                    registerOrganizationDto.TIN,
                    logo == null ? null : CreateOrganizationLogo.New(logo),
                    images == null ? Enumerable.Empty<CreateImage>() : images.Select(CreateImage.New)))));
        }
    }
}