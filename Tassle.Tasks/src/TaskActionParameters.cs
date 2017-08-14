﻿// --------------------------------------------------------------------------
// <copyright file="TaskActionParameters.cs" company="-">
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
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Tassle.Tasks {
    /// <summary>
    /// TaskActionParameters class.
    /// </summary>
    public class TaskActionParameters : IDisposable {
        // fields

        /// <summary>
        /// The source
        /// </summary>
        private readonly TaskItem _source;

        /// <summary>
        /// The action started
        /// </summary>
        private readonly DateTimeOffset _actionStarted;

        /// <summary>
        /// The cancellation token source
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        // constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskActionParameters" /> class.
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="actionStarted">The action started</param>
        /// <param name="cancellationTokenSource">The cancellation token source</param>
        public TaskActionParameters(TaskItem source, DateTimeOffset actionStarted, CancellationTokenSource cancellationTokenSource) {
            this._source = source;
            this._actionStarted = actionStarted;
            this._cancellationTokenSource = cancellationTokenSource;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TaskActionParameters"/> class.
        /// </summary>
        ~TaskActionParameters() {
            this.Dispose(false);
        }

        // properties

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public TaskItem Source {
            get => this._source;
        }

        /// <summary>
        /// Gets the action started.
        /// </summary>
        /// <value>
        /// The action started.
        /// </value>
        public DateTimeOffset ActionStarted {
            get => this._actionStarted;
        }

        /// <summary>
        /// Gets the cancellation token source.
        /// </summary>
        /// <value>
        /// The cancellation token source.
        /// </value>
        public CancellationTokenSource CancellationTokenSource {
            get => this._cancellationTokenSource;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Service"/> is disposed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disposed; otherwise, <c>false</c>.
        /// </value>
        public bool Disposed {
            get => this._disposed;
            protected set => this._disposed = value;
        }

        // methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Called when [dispose].
        /// </summary>
        /// <param name="releaseManagedResources"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources</param>
        protected virtual void OnDispose(bool releaseManagedResources) {
            if (this._cancellationTokenSource != null) {
                this._cancellationTokenSource.Dispose();
                this._cancellationTokenSource = null;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="releaseManagedResources"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources</param>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "cancellationTokenSource")]
        protected void Dispose(bool releaseManagedResources) {
            if (this.Disposed) {
                return;
            }

            this.OnDispose(releaseManagedResources);

            this.Disposed = true;
        }
    }
}