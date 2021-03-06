// --------------------------------------------------------------------------
// <copyright file="IRuleSet{T}.cs" company="-">
//   Copyright (c) 2008-2019 Eser Ozvataf (eser@ozvataf.com). All rights reserved.
//   Licensed under the Apache-2.0 license. See LICENSE file in the project root
//   for full license information.
//
//   Web: http://eser.ozvataf.com/ GitHub: http://github.com/eserozvataf
// </copyright>
// <author>Eser Ozvataf (eser@ozvataf.com)</author>
// --------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Tassle.Validation {
    public interface IRuleSet<T> {
        void Add(Expression<Func<T, bool>> predicate);

        bool CheckFor(T target);
    }
}
