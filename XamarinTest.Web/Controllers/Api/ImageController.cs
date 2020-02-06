using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using XamarinTest.ApiModels.Models;
using XamarinTest.Domain.Interfaces.Services;

namespace XamarinTest.Web.Controllers.Api {
    [Authorize]
    public class ImageController : ApiController {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IImageService _ImageService;

        public ImageController(IMapper mapper, IUserService userService, IImageService imageService) {
            _mapper = mapper;
            _userService = userService;
            _ImageService = imageService;
        }

        [Route("api/Image/Save")]
        [HttpPost]
        public IHttpActionResult Save(string latitude, string longitude) {
            try {
                var httpRequest = HttpContext.Current.Request;
                var files = httpRequest.Files.Count;
                if (files == 0) {
                    return BadRequest("Error loading image");
                }

                var image = httpRequest.Files.Get("image");
                var stream = image.InputStream;

                BinaryReader reader = new BinaryReader(stream);
                byte[] imageBytes = reader.ReadBytes((Int32)stream.Length);
                double l1 = double.Parse(latitude);
                double l2 = double.Parse(longitude);

                Guid userId = Guid.Parse(User.Identity.GetUserId());

                _ImageService.Save(userId, imageBytes, l1, l2);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Image/List")]
        [HttpGet]
        public IHttpActionResult List() {
            try {
                Guid userId = Guid.Parse(User.Identity.GetUserId());
                var entities = _ImageService.ListByUserId(userId);
                var images = _mapper.Map<IEnumerable<ImageApiModel>>(entities);
                return Ok(images);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
