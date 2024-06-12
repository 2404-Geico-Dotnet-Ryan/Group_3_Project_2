using Project2.DTOs;
using Project2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        // Constructor to inject the purchase service
        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // GET: /Purchases
        // Action method to handle GET requests to retrieve all purchases
        [HttpGet]
        public ActionResult<IEnumerable<PurchaseDTO>> GetPurchases()
        {
            var purchases = _purchaseService.GetAllPurchases();
            return Ok(purchases);
        }

        // GET: /Purchases/{PurchaseId}
        // Action method to handle GET requests to retrieve a purchase by their ID
        [HttpGet("{PurchaseId}")]
        public ActionResult<PurchaseDTO> GetPurchaseById(int PurchaseId)
        {
            var purchase = _purchaseService.GetPurchaseById(PurchaseId);
            return purchase;
        }

        // POST: /Purchases
        // Action method to handle POST requests to create a new purchase
        [HttpPost]
        public ActionResult<PurchaseDTO> PostPurchase(PurchaseDTO purchaseDto)
        {
            var purchase = _purchaseService.CreatePurchase(purchaseDto);
            return CreatedAtAction(nameof(GetPurchaseById), new { PurchaseId = purchase.PurchaseId }, purchaseDto);
        }

        // PUT: /Purchases/{PurchaseId}
        // Action method to handle PUT requests to update an existing purchase
        [HttpPut("{PurchaseId}")]
        public ActionResult<PurchaseDTO> UpdatePurchase(int PurchaseId, PurchaseDTO UpdatedPurchase)
        {
            _purchaseService.UpdatedPurchase(PurchaseId, UpdatedPurchase);
            return Ok(UpdatedPurchase);
        }

        // DELETE: /Purchases/{PurchaseId}
        // Action method to handle DELETE requests to delete a purchase by their ID
        [HttpDelete("{PurchaseId}")]
        public IActionResult DeletePurchase(int PurchaseId)
        {
            _purchaseService.DeletePurchase(PurchaseId);
            return Ok();
        }
    }
}