using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGames.DataAccess.Repository;
using VideoGames.DataAccess.Repository.IRepository;
using VideoGames.Models;
using VideoGames.Utility;

namespace VideoGamesApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OrderController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;

		public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			return View();
		}

		#region Api Calls
		[HttpGet]
		public IActionResult GetAll(string status)
		{
			IEnumerable<OrderHeader> objIOrderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();

			switch (status)
			{
                case "pending":
                    objIOrderHeaderList = objIOrderHeaderList.Where(u=>u.PaymentStatus==SD.PaymentStatusDelayPayment);
                    break;
                case "inprocess":
                    objIOrderHeaderList = objIOrderHeaderList.Where(u => u.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    objIOrderHeaderList = objIOrderHeaderList.Where(u => u.OrderStatus == SD.StatusShipped);
                    break;
                case "approved":
                    objIOrderHeaderList = objIOrderHeaderList.Where(u => u.OrderStatus == SD.StatusApproved);
                    break;
                default:                    
                    break;
            }
			
			return Json(new { data = objIOrderHeaderList });
		}

		#endregion
	}
}
