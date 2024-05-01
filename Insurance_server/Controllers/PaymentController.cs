using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insurance_server.Models;


namespace Insurance_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly InsuranceDbContext _context;

        public PaymentDetailsController(InsuranceDbContext context)
        {
            _context = context;
        }

        // GET: api
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetails
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api
        [HttpPut]
        public async Task<IActionResult> Put(PaymentDetail payment)
        {
            if (payment == null || payment.PaymentId == 0)
                return BadRequest();

            var paymentInfo = await _context.PaymentDetails.FindAsync(payment.PaymentId);
            if (paymentInfo == null)
                return NotFound();
            paymentInfo.CardOwnerName = payment.CardOwnerName;
            paymentInfo.CardNumber = payment.CardNumber;
            paymentInfo.SecurityCode = payment.SecurityCode;
            paymentInfo.ValidThrough = payment.ValidThrough;

            await _context.SaveChangesAsync();
            return Ok();
        }


        // POST: api
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentDetail), new { id = paymentDetail.PaymentId }, paymentDetail);
        }

        // DELETE: api
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.PaymentDetails.FindAsync(id);
            if (product == null)
                return NotFound();
            _context.PaymentDetails.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();

        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentId == id);
        }
    }
}
