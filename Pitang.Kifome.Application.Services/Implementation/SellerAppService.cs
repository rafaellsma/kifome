using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Services.Implementation
{
    public class SellerAppService : ISellerAppService
    {
        private readonly ISellerService sellerService;
        public SellerAppService(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        #region Meal
        public void RegisterMeal(MealInputDTO meal)
        {
            sellerService.RegisterMeal(new Meal
            {
                Name = meal.Name,
                Description = meal.Description,
                Price = meal.Price,
                MenuId = meal.MenuId,
                Days = meal.Days
            });
        }

        public void UpdateMeal(MealInputDTO meal)
        {
            this.sellerService.UpdateMeal(new Meal
            {
                Name = meal.Name,
                Description = meal.Description,
                Price = meal.Price,
                Days = meal.Days,
                MenuId = meal.MenuId
            });
        }

        public void DeleteMeal(int Id)
        {
            this.sellerService.DeleteMeal(Id);
        }

        public IList<MealOutputDTO> GetMeals()
        {
            var meals = this.sellerService.GetMeals();
            IList<MealOutputDTO> mealsDTO = new List<MealOutputDTO>();
            foreach (var m in meals)
            {
                IList<GarnishOutputDTO> garnishDTO = new List<GarnishOutputDTO>();
                //Casting Entity Garnish into GarnishOutputDTO
                foreach (var g in m.Garnishies)
                {
                    GarnishOutputDTO garnish = new GarnishOutputDTO()
                    {
                        Name =  g.Name,
                        Description = g.Description
                    };
                    garnishDTO.Add(garnish);
                }
                //Casting Entity Meal into MealOutputDTO
                MealOutputDTO meal = new MealOutputDTO
                {
                    Name = m.Name,
                    Garnishies = garnishDTO, //Entity GarnishOutputDTO 
                    Price = m.Price,
                    Description = m.Description,
                    Days = m.Days
                };
                mealsDTO.Add(meal);
            }
            return mealsDTO;
        }

        public IList<MealOutputDTO> GetMealByFilters(MealFiltersDTO mealFilters)
        {
            throw new NotImplementedException();
        }

        public MealOutputDTO GetMealById(int Id)
        {
            var meal = this.sellerService.GetMealById(Id);
            IList<GarnishOutputDTO> garnishDTO = new List<GarnishOutputDTO>();
            //Casting Entity Garnish into GarnishOutputDTO
            foreach (var g in meal.Garnishies)
            {
                GarnishOutputDTO garnish = new GarnishOutputDTO()
                {
                    Name = g.Name,
                    Description = g.Description
                };
                garnishDTO.Add(garnish);
            }
            MealOutputDTO mealDTO = new MealOutputDTO()
            {
                 Name = meal.Name,
                 Description = meal.Description,
                 Price = meal.Price,
                 Days = meal.Days,
                 Garnishies = garnishDTO
            };
            return mealDTO;
        }
        #endregion
        #region Garnish
        public IList<GarnishOutputDTO> GetGarnishes()
        {
            var garnishes = sellerService.GetGarnishes();
            IList<GarnishOutputDTO> garnishesOutput = new List<GarnishOutputDTO>();
            foreach (var garnish in garnishes)
            {
                garnishesOutput.Add(new GarnishOutputDTO()
                {
                    Name = garnish.Name,
                    Description = garnish.Description
                });
            }
            return garnishesOutput;

        }

        public void RegisterGarnish(GarnishInputDTO garnish)
        {
            sellerService.RegisterGarnish(new Garnish
            {
                Name = garnish.Name,
                Description = garnish.Description
            });
        }
        #endregion
        #region Menu
        public void RegisterMenu(MenuInputDTO menu)
        {
            sellerService.RegisterMenu(new Menu
            {
                LimitOfMeals = menu.LimitOfMeals,
                InitialHour = Convert.ToDateTime(menu.InitialTimeToOrder),
                FinalHour = Convert.ToDateTime(menu.FinalTimeToOrder),
                SellerId = menu.SellerId,
                Id = menu.SellerId
            });
        }
        #endregion
        #region Withdrawal
        public void RegisterWithdrawal(WithdrawalInputDTO withdrawal)
        {
            sellerService.RegisterWithdrawal(new Withdrawal
            {
                Street = withdrawal.Street,
                Number = withdrawal.Number,
                CEP = withdrawal.CEP,
                InitialHour = Convert.ToDateTime(withdrawal.InitailHour),
                FinalHour = Convert.ToDateTime(withdrawal.FinalHour),
                Latitude = withdrawal.Latitude,
                Longitude = withdrawal.Longitude,
                SellerId = withdrawal.SellerId
            });
        }

        public IList<WithdrawalOutputDTO> GetWithdrawals()
        {
            throw new NotImplementedException();
        }

        public WithdrawalOutputDTO GetWithdrawalById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateWithdrawal(WithdrawalUpdateInputDTO withdrawal)
        {
            throw new NotImplementedException();
        }

        public void DeleteWithdrawal(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
