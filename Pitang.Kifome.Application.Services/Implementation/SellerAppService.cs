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
        private readonly IUserService userService;
        public SellerAppService(ISellerService sellerService, IUserService userService)
        {
            this.sellerService = sellerService;
            this.userService = userService;
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
        

        public void RegisterGarnish(GarnishInputDTO garnish)
        {
            sellerService.RegisterGarnish(new Garnish
            {
                Name = garnish.Name,
                Description = garnish.Description
            });
        }

        public void UpdateGarnish(GarnishUpdateDTO garnish)
        {
            sellerService.UpdateGarnish(new Garnish()
            {
                Name = garnish.Name,
                Description = garnish.Description,
                Id = garnish.Id
            });
        }

        public void DeleteGarnish(int id)
        {
            var garnish = userService.GetGarnishById(id);
            sellerService.DeleteGarnish(garnish);
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

        public MenuOutputDTO GetMenuBySellerId(int id)
        {
            var menu = sellerService.GetMenuBySellerId(id);
            menu.Seller = userService.GetUserById(menu.SellerId);
            menu.Meals = sellerService.GetMealsByMenuId(menu.Id);
            IList<string> mealsNames = new List<string>();
            foreach (var meal in menu.Meals)
            {
                mealsNames.Add(meal.Name);
            }
            MenuOutputDTO menuOutput = new MenuOutputDTO
            {
                LimitOfMeals = menu.LimitOfMeals,
                InitialTimeToOrder = menu.InitialHour.ToShortTimeString(),
                FinalTimeToOrder = menu.FinalHour.ToShortTimeString(),
                MealsNames = mealsNames,
                SellerName = menu.Seller.Name
            };
            return menuOutput;
        }

        public void UpdateMenu(MenuUpdateInputDTO menu)
        {
            sellerService.UpdateMenu(new Menu
            {
                Id = menu.SellerId,
                LimitOfMeals = menu.LimitOfMeals,
                InitialHour = Convert.ToDateTime(menu.InitialTimeToOrder),
                FinalHour = Convert.ToDateTime(menu.FinalTimeToOrder),
                SellerId = menu.SellerId
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
                InitialHour = Convert.ToDateTime(withdrawal.InitialHour),
                FinalHour = Convert.ToDateTime(withdrawal.FinalHour),
                Latitude = withdrawal.Latitude,
                Longitude = withdrawal.Longitude,
                SellerId = withdrawal.SellerId
            });
        }

        public IList<WithdrawalOutputDTO> GetWithdrawals()
        {
            var withdrawals = sellerService.GetWithdrawals();
            IList<WithdrawalOutputDTO> withdrawalsOutput = new List<WithdrawalOutputDTO>();
            foreach (var withdrawal in withdrawals)
            {
                withdrawal.Seller = userService.GetUserById(withdrawal.SellerId);
                withdrawalsOutput.Add(new WithdrawalOutputDTO
                {
                    Street = withdrawal.Street,
                    Number = withdrawal.Number,
                    CEP = withdrawal.CEP,
                    InitialHour = withdrawal.InitialHour.ToShortTimeString(),
                    FinalHour = withdrawal.FinalHour.ToShortTimeString(),
                    Latitude = withdrawal.Latitude,
                    Longitude = withdrawal.Longitude,
                    SellerName = withdrawal.Seller.Name
                });
            }
            return withdrawalsOutput;
        }

        public IList<WithdrawalOutputDTO> GetWithdrawalsBySellerId(int id)
        {
            var withdrawals = sellerService.GetWithdrawalsBySellerId(id);
            IList<WithdrawalOutputDTO> withdrawalsOutput = new List<WithdrawalOutputDTO>();
            foreach (var withdrawal in withdrawals)
            {
                withdrawal.Seller = userService.GetUserById(withdrawal.SellerId);
                withdrawalsOutput.Add(new WithdrawalOutputDTO
                {
                    Street = withdrawal.Street,
                    Number = withdrawal.Number,
                    CEP = withdrawal.CEP,
                    InitialHour = withdrawal.InitialHour.ToShortTimeString(),
                    FinalHour = withdrawal.FinalHour.ToShortTimeString(),
                    Latitude = withdrawal.Latitude,
                    Longitude = withdrawal.Longitude,
                    SellerName = withdrawal.Seller.Name
                });
            }
            return withdrawalsOutput;
        }

        public WithdrawalOutputDTO GetWithdrawalById(int id)
        {
            var withdrawal = sellerService.GetWithdrawalById(id);
            withdrawal.Seller = userService.GetUserById(withdrawal.SellerId);
            WithdrawalOutputDTO withdrawalOutput = new WithdrawalOutputDTO
            {
                Street = withdrawal.Street,
                Number = withdrawal.Number,
                CEP = withdrawal.CEP,
                InitialHour = withdrawal.InitialHour.ToShortTimeString(),
                FinalHour = withdrawal.FinalHour.ToShortTimeString(),
                Latitude = withdrawal.Latitude,
                Longitude = withdrawal.Longitude,
                SellerName = withdrawal.Seller.Name
            };
            return withdrawalOutput;
        }

        public void UpdateWithdrawal(WithdrawalUpdateInputDTO withdrawal)
        {
            sellerService.UpdateWithdrawal(new Withdrawal
            {
                Id = withdrawal.Id,
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

        public void DeleteWithdrawal(int id)
        {
            sellerService.DeleteWithdrawal(id);
        }
        #endregion
    }
}
