using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NewsForYou.Business;
using NewsForYou.DAL.Models;
using NewsForYou.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsForYou.Controllers
{
    [Route("api")]
    [ApiController]
    public class NewsForYouController : ControllerBase
    {
        private IService _service;
        private IConfiguration config;

        public NewsForYouController(IService service,IConfiguration configuration)
        {
            _service = service;
            config = configuration;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(UserModel model)
        {
            bool flag = await _service.SignUp(model);
            return Ok(new { flag});
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            UserModel result=await _service.Login(model);
            return Ok(new { authenticate = result!=null, jwtToken = GenerateToken(result) });
        }

        private string GenerateJwtToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyWithAtLeast16Bytes"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name)
                };

            var token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateToken(UserModel userCredentials)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"], null, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("category")]
        [Authorize]
        public async Task<IActionResult> AddCategory(CategoryModel model)
        {
            bool flag = await _service.AddCategory(model);
            return Ok(new { flag });
        }

        [HttpPost]
        [Route("agency")]
        [Authorize]
        public async Task<IActionResult> AddAgency(AgencyModel model)
        {
            bool flag = await _service.AddAgency(model);
            return Ok(new { flag});
        }

        [HttpPost]
        [Route("addagencyfeed")]
        [Authorize]
        public async Task<IActionResult> AddAgencyFeed(AgencyFeedModel model)
        {
            bool flag = await _service.AddAgencyFeed(model);
            return Ok(new { flag });
        }

        [HttpGet]
        [Route("category")]
        [Authorize]
        public async Task<IActionResult> GetCategory()
        {
            List<CategoryModel> result = await _service.GetCategory();
            return Ok(new { result });
        }

        [HttpGet]
        [Route("agency")]
        public async Task<IActionResult> GetAgency()
        {
            List<AgencyModel> result = await _service.GetAgency();
            return Ok( new {result});
        }

        [HttpDelete]
        [Route("deleteall")]
        [Authorize]
        public async Task<IActionResult> DeleteAllNews()
        {
            bool flag= await _service.DeleteAllNews();
            return Ok(new {flag});
        }

        [HttpGet]
        [Route("getcategoriesfromagencyid")]
        public async Task<IActionResult> GetCategoriesFromAgencyId(int id)
        {
            List < CategoryModel > category= await _service.GetCategoriesFromAgencyId(id); ;
            return Ok(new{ category});
        }

        [HttpGet]
        [Route("getallnews")]
        public async Task<IActionResult> GetAllNews(int id)
        {
            List < NewsModel > allnews= await _service.GetAllNews(id);
            return Ok(new { allnews });
        }

        [HttpPost]
        [Route("report")]
        [Authorize]
        public async Task<IActionResult> GeneratePdf(ExportModel export)
        {
            List < ReportModel > report= await _service.GeneratePdf(export.Start, export.End); 
            return Ok(new { report });
        }

        [HttpPost]
        [Route("getnewsbycategories")]
        public async Task<IActionResult> GetNewsByCategories(GetNewsByCategoriesModel model)
        {
            List < NewsModel > getnesfromcategory= await _service.GetNewsByCategories(model.Categories, model.Id); ;
            return Ok(new { getnesfromcategory });
        }

        [HttpGet]
        [Route("incrementnewsclickcount")]
        public async Task<IActionResult> IncrementNewsClickCount(int id)
        {
            bool flag = await _service.IncrementNewsClickCount(id);
            return Ok(new { flag });
        }

        [HttpGet]
        [Route("checkemail")]
        public async Task<IActionResult> FindEmail(string id)
        {
            bool flag = await _service.FindEmail(id);
            return Ok(new { flag });
        }
    }
}
