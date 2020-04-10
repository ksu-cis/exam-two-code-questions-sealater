using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        FruitFilling _fruit;
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit
        {
            get => _fruit;
            set
            {
                if (_fruit == value)
                    return;

                _fruit = value;
                InvokePropertyChanged("Fruit");
            }
        }

        bool _withIceCream = true;
        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream
        {
            get => _withIceCream;
            set
            {
                if (_withIceCream == value)
                    return;

                _withIceCream = value;
                InvokePropertyChanged("WithIceCream");
                InvokePropertyChanged("Price"); // Price also changes
                InvokePropertyChanged("SpecialInstructions"); // SpecialInstructions also changes
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else return 4.25;
            }
        }

        /// <summary>
        /// Helper method to trigger PropertyChanged events
        /// </summary>
        /// <param name="propertyName"></param>
        protected void InvokePropertyChanged(string propertyName)
        {
            Debug.WriteLine($"{propertyName} Property Changed"); // Prints to Debug to test property changing
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }
    }
}
