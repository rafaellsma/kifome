using AutoMapper;
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
        private readonly IMapper mapper;
        public SellerAppService(ISellerService sellerService, IUserService userService, IMapper mapper)
        {
            this.sellerService = sellerService;
            this.userService = userService;
            this.mapper = mapper;
        }

        #region Meal
        public void RegisterMeal(MealInputDTO meal)
        {
            IList<Garnish> garnishies = new List<Garnish>();
            if (meal.GarnishiesId != null)
            {
                foreach (var g in meal.GarnishiesId)
                {
                    garnishies.Add(userService.GetGarnishById(g)); 
                }
            }
            
            sellerService.RegisterMeal(new Meal
            {
                Name = meal.Name,
                Description = meal.Description,
                Price = meal.Price,
                MenuId = meal.MenuId,
                Days = meal.Days,
                Garnishies = garnishies
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
            var meals = sellerService.GetMeals();
            IList<MealOutputDTO> mealsDTO = new List<MealOutputDTO>();
            foreach (var m in meals)
            {
                IList<string> garnishiesNames = new List<string>();
                if (m.Garnishies != null)
                {
                    foreach (var g in m.Garnishies)
                    {
                        garnishiesNames.Add(g.Name);
                    }
                }
                MealOutputDTO meal = new MealOutputDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    GarnishiesName = garnishiesNames,
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
            IList<string> garnishiesNames = new List<string>();
            if (meal.Garnishies != null)
            {
                foreach (var g in meal.Garnishies)
                {
                    garnishiesNames.Add(g.Name);
                }
            }
            MealOutputDTO mealDTO = new MealOutputDTO()
            {
                Id = meal.Id,
                Name = meal.Name,
                Description = meal.Description,
                Price = meal.Price,
                Days = meal.Days,
                GarnishiesName = garnishiesNames
            };
            return mealDTO;
        }
        #endregion

        #region Garnish
        public void RegisterGarnish(GarnishInputDTO garnish)
        {
            sellerService.RegisterGarnish(mapper.Map<Garnish>(garnish));
        }

        public void UpdateGarnish(GarnishUpdateDTO garnish)
        {
            sellerService.UpdateGarnish(mapper.Map<Garnish>(garnish));
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
