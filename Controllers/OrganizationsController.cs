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


        [HttpGet]
        public Task<IEnumerable<OrganizationFullDto>> GetOrganizations() => _organizationsService.GetAllAsync();

        [HttpGet("{guid:guid}")]
        public Task<OrganizationFullDto> GetOrganization(Guid guid) => _organizationsService.GetByGuidAsync(guid);

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> Register(RegisterOrganizationDto registerOrganizationDto)
        {
            return Ok(await _organizationsService.RegisterOrganizationAsync(
                Organization.New(CreateOrganization.New(
                    OrganizationType.GetById(registerOrganizationDto.OrganizationTypeId),
                    new CreateOrUpdateContacts(
                        registerOrganizationDto.Contacts.ActualAddress,
                        registerOrganizationDto.Contacts.ActualGeoPosition,
                        registerOrganizationDto.Contacts.PhoneNumber,
                        registerOrganizationDto.Contacts.Email,
                        registerOrganizationDto.Contacts.Site,
                        registerOrganizationDto.Contacts.Telegram,
                        registerOrganizationDto.Contacts.Instagram,
                        registerOrganizationDto.Contacts.Vk),
                    registerOrganizationDto.LegalName,
                    registerOrganizationDto.LegalAddress,
                    registerOrganizationDto.ActualName,
                    registerOrganizationDto.TIN,
                    registerOrganizationDto.Logo == null
                        ? null
                        : CreateOrganizationLogo.New(registerOrganizationDto.Logo),
                    registerOrganizationDto.Images == null
                        ? null
                        : registerOrganizationDto.Images.Select(CreateImage.New)))));
        }
    }
}