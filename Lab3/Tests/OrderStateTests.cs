using Xunit;
using FoodDelivery.Models;
using FoodDelivery.Patterns.State;

namespace FoodDelivery.Tests
{
    public class OrderStateTests
    {
        [Fact]
        public void CreatedState_Next_TransitionsToPreparingState()
        {
            var order = new Order();
            
            order.NextState();
            
            Assert.Equal("Preparing", order.GetStateName());
        }

        [Fact]
        public void PreparingState_Next_TransitionsToDeliveringState()
        {
            var order = new Order();
            order.SetState(new PreparingState());
            
            order.NextState();
            
            Assert.Equal("Delivering", order.GetStateName());
        }

        [Fact]
        public void DeliveringState_Next_TransitionsToCompletedState()
        {
            var order = new Order();
            order.SetState(new DeliveringState());
            
            order.NextState();
            
            Assert.Equal("Completed", order.GetStateName());
        }

        [Fact]
        public void CompletedState_Next_RemainsCompleted()
        {
            var order = new Order();
            order.SetState(new CompletedState());
            
            order.NextState();
            
            Assert.Equal("Completed", order.GetStateName());
        }

        [Fact]
        public void Order_StateTransitions_FullCycle()
        {
            var order = new Order();
            Assert.Equal("Created", order.GetStateName());
            
            order.NextState();
            Assert.Equal("Preparing", order.GetStateName());
            
            order.NextState();
            Assert.Equal("Delivering", order.GetStateName());
            
            order.NextState();
            Assert.Equal("Completed", order.GetStateName());
        }
    }
}
