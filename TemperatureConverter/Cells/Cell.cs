using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cells
{
    public class Cell<T> : INotifyPropertyChanged
    // We turn Cell into a generic class Cell<T>
    {
        private T contents;

        public Cell(T initialContents = default(T))
        // default(T) gives the right default value. Boolean don't have null for example.
        {
            this.contents = initialContents;
        }

        public T Value
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
