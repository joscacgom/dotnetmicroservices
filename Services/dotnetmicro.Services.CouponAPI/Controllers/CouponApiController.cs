using AutoMapper;
using dotnetmicro.Services.CouponAPI.Data;
using dotnetmicro.Services.CouponAPI.Models;
using dotnetmicro.Services.CouponAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace dotnetmicro.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
           try{
                IEnumerable<Coupon> coupons = _context.Coupons.ToList();
                ResponseDTO _response = new ResponseDTO();
                _response.Result = _mapper.Map<List<CouponDTO>>(coupons);
                _response.IsSuccess = true;
                
                return Ok(_response);
            }
           catch(Exception ex){
                ResponseDTO _response = new ResponseDTO();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                Coupon? coupon = _context.Coupons.FirstOrDefault(c => c.Id == id);
                ResponseDTO _response = new ResponseDTO();
                if (coupon == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Coupon not found";
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<CouponDTO>(coupon);
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                ResponseDTO _response = new ResponseDTO();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpGet]
        [Route("GetByCouponCode/{code}")]
        public IActionResult GetByCouponCode(string code)
        {
            try
            {
                Console.WriteLine(code);
                Coupon? coupon = _context.Coupons.FirstOrDefault(c => c.CouponCode.ToLower().Equals(code.ToLower()));
                ResponseDTO _response = new ResponseDTO();
                if (coupon == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Coupon not found";
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<CouponDTO>(coupon);
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                ResponseDTO _response = new ResponseDTO();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDTO);
                _context.Coupons.Add(coupon);
                _context.SaveChanges();
                ResponseDTO _response = new ResponseDTO();
                _response.Result = _mapper.Map<CouponDTO>(coupon);
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                ResponseDTO _response = new ResponseDTO();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDTO);
                _context.Coupons.Update(coupon);
                _context.SaveChanges();
                ResponseDTO _response = new ResponseDTO();
                _response.Result = _mapper.Map<CouponDTO>(coupon);
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                ResponseDTO _response = new ResponseDTO();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Coupon? coupon = _context.Coupons.FirstOrDefault(c => c.Id == id);
                ResponseDTO _response = new ResponseDTO();
                if (coupon == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Coupon not found";
                    return NotFound(_response);
                }
                _context.Coupons.Remove(coupon);
                _context.SaveChanges();
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                ResponseDTO _response = new ResponseDTO();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }
    }

}