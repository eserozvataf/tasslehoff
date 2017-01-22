﻿// --------------------------------------------------------------------------
// <copyright file="TelnetLogScope.cs" company="-">
// Copyright (c) 2008-2017 Eser Ozvataf (eser@ozvataf.com). All rights reserved.
// Web: http://eser.ozvataf.com/ GitHub: http://github.com/eserozvataf
// </copyright>
// <author>Eser Ozvataf (eser@ozvataf.com)</author>
// --------------------------------------------------------------------------

//// This program is free software: you can redistribute it and/or modify
//// it under the terms of the GNU General Public License as published by
//// the Free Software Foundation, either version 3 of the License, or
//// (at your option) any later version.
//// 
//// This program is distributed in the hope that it will be useful,
//// but WITHOUT ANY WARRANTY; without even the implied warranty of
//// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//// GNU General Public License for more details.
////
//// You should have received a copy of the GNU General Public License
//// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Threading;

namespace Tassle.Logging.Telnet {
    public class TelnetLogScope {
        // fields

        private static AsyncLocal<TelnetLogScope> s_value = new AsyncLocal<TelnetLogScope>();

        private readonly string _name;
        private readonly object _state;

        private TelnetLogScope _parent;

        // constructors

        internal TelnetLogScope(string name, object state) {
            this._name = name;
            this._state = state;
        }

        internal TelnetLogScope(string name, object state, TelnetLogScope parent) : this(name, state) {
            this._parent = parent;
        }

        // properties
        public static TelnetLogScope Current {
            get => TelnetLogScope.s_value.Value;
        }

        public TelnetLogScope Parent {
            get => this._parent;
        }

        // methods

        public static IDisposable Push(string name, object state) {
            var parent = TelnetLogScope.Current;

            TelnetLogScope.s_value.Value = new TelnetLogScope(name, state, parent);

            return new DisposableScope();
        }

        public override string ToString() {
            return this._state?.ToString();
        }

        private class DisposableScope : IDisposable {
            public void Dispose() {
                TelnetLogScope.s_value.Value = TelnetLogScope.s_value.Value.Parent;
            }
        }
    }
}