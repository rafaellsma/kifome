using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using Pitang.Kifome.Infra.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Variables

        private DbContext context;
        private bool disposed;


        #endregion

        #region Constructor

        public UnitOfWork()
        {
            this.context = new Context();
            this.disposed = false;
        }
        #endregion

        #region Props

        private IGarnishRepository garnishRepository;
        public IGarnishRepository GarnishRepository
        {
            get
            {
                if (this.garnishRepository == null)
                {
                    this.garnishRepository = new GarnishRepository(context);
                }
                return this.garnishRepository;
            }
        }

        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return this.userRepository;
            }
        }

        private IOrderRepository orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository(context);
                }
                return this.orderRepository;
            }
        }

        private IMenuRepository menuRepository;
        public IMenuRepository MenuRepository
        {
            get
            {
                if (this.menuRepository == null)
                {
                    this.menuRepository = new MenuRepository(context);
                }
                return this.menuRepository;
            }
        }

        private IMealRepository mealRepository;
        public IMealRepository MealRepository
        {
            get
            {
                if (this.mealRepository == null)
                {
                    this.mealRepository = new MealRepository(context);
                }
                return this.mealRepository;
            }
        }

        private IWithdrawalRepository withdrawalRepository;
        public IWithdrawalRepository WithdrawalRepository
        {
            get
            {
                if (this.withdrawalRepository == null)
                {
                    this.withdrawalRepository = new WithdrawalRepository(context);
                }
                return this.withdrawalRepository;
            }
        }

        private ICommentRepository commentRepository;
        public ICommentRepository CommentRepository
        {
            get
            {
                if (this.commentRepository == null)
                {
                    this.commentRepository = new CommentRepository(context);
                }
                return this.commentRepository;
            }
        }

        

        #endregion



        #region Dispose Pattern


        private void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                context.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
