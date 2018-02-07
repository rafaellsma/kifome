using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Application.Entities.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers:"*", methods: "*")]
    public class MealController : ApiController
    {
        private readonly ISellerAppService sellerAppService;
        public MealController(ISellerAppService sellerAppServiceInstance)
        {
            this.sellerAppService = sellerAppServiceInstance;
        }

        [AcceptVerbs("Post")]
        [Route("meal")]
        public void CreateMeal(MealInputDTO meal)
        {
            this.sellerAppService.RegisterMeal(meal);
        }
        [AcceptVerbs("Get")]
        [Route("meal")]
        public IList<MealOutputDTO> GetMeals()
        {
            return this.sellerAppService.GetMeals();
        }

        [AcceptVerbs("Get")]
        [Route("meal/{id}")]
        public MealOutputDTO GetMealById(int Id)
        {
            return this.sellerAppService.GetMealById(Id);
        }

        [AcceptVerbs("Post")]
        [Route("meal/filters")]
        public IList<MealOutputDTO> GetMealByFilters(MealFiltersDTO mealFilters)
        {
            return this.sellerAppService.GetMealByFilters(mealFilters);
        }

        [AcceptVerbs("Put")]
        [Route("meal")]
        public void UpdateMeal(MealUpdateInputeDTO meal)
        {
            this.sellerAppService.UpdateMeal(meal);
        }

        [AcceptVerbs("Delete")]
        [Route("meal/{id}")]
        public void DeleteMeal(int Id)
        {
            this.sellerAppService.DeleteMeal(Id);
        }
    }
}