// --------------------------------------------------------------------------
// <copyright file="DebugLogger.cs" company="-">
// Copyright (c) 2008-2016 Eser Ozvataf (eser@ozvataf.com). All rights reserved.
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

using System.Diagnostics;

namespace Tasslehoff.Logging.Loggers
{
    /// <summary>
    /// DebugLogger class.
    /// </summary>
    public class DebugLogger
    {
        // constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogger"/> class.
        /// </summary>
        public DebugLogger()
        {
        }

        // methods

        /// <summary>
        /// Attachs itself to the log system.
        /// </summary>
        public void Attach()
        {
            LoggerContext.Current.LogEntryPopped += this.OnLogEntryPopped;
        }

        /// <summary>
        /// Detachs itself from the log system.
        /// </summary>
        public void Detach()
        {
            LoggerContext.Current.LogEntryPopped -= this.OnLogEntryPopped;
        }

        /// <summary>
        /// Calls when an log entry popped
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="entry">The log entry</param>
        private void OnLogEntryPopped(object sender, LogEntry entry)
        {
            var content = LoggerContext.Current.Formatter.Apply(entry);

            Debug.Write(content);
        }
    }
}
