using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cells
{
    public class Cell<T> : INotifyPropertyChanged
    {
        private T contents;

        public Cell(T initialContents = default(T))
        {
            this.contents = initialContents;
        }

        public virtual T Value
        // We want to override the Value property. For this to be possible, C# requires you to declare it
        // virtual is the base class. virtual basically means "people can override this member in subclasses.
        {
            get
            {
                return contents;
            }
            set
            {
                this.contents = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        public Cell<U> Derive<U>(Func<T, U> transformer, Func<U, T> untransformer)
        {
            return new Derived<T, U>(this, transformer, untransformer);
        }
        // The initial contents of the Derived is specified by : base(transformer(dependency.Value)):
        // it takes the value of the dependent cell (kelvin) and transforms it (k - 273.15)

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Derived<IN, OUT>: Cell<OUT>
        //derived<IN, OUT> = subclass of Cell<OUT>

        //The IN type parameter is the type of the original cell's value (kelvin). The OUT type parameter is the 
        //type of the new cell (celsius). In our specific case, IN = OUT = double
    {
        private readonly Cell<IN> dependency;

        private readonly Func<IN, OUT> transformer;

        private readonly Func<OUT, IN> untransformer;

        public Derived(Cell<IN> dependency, Func<IN, OUT> transformer, Func<OUT, IN> untransformer) : base(transformer(dependency.Value))
        {
            this.dependency = dependency;
            this.transformer = transformer;
            this.untransformer = untransformer;

            this.dependency.PropertyChanged += (sender, args) => base.Value = transformer(dependency.Value);
            //base.Value = transformer(dependency.Value) will be executed. In other words, the constructor's
            //last line states "Each time my dependency's value changes, recompute my own value."
        }

        public override OUT Value
        {
            get
            {
                return base.Value;
            }

            set
            {
                this.dependency.Value = untransformer(value);
            }
        }
    }
}