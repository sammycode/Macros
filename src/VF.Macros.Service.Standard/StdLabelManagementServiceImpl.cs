/*
 * Copyright (C) 2018  Mike Jamer
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using VF.Macros.Data;
using DataContract = VF.Macros.Common.Models;
using DataEntity = VF.Macros.Data.Entity;

namespace VF.Macros.Service.Standard
{

    /// <summary>
    /// The Standard Label Management Service Implementation
    /// </summary>
    public class StdLabelManagementServiceImpl : ILabelManagementService
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(StdLabelManagementServiceImpl));

        /// <summary>
        /// The Data Repository
        /// </summary>
        private IDataRepository _dataRepository;

        /// <summary>
        /// Initialize Standard Label Management Service Implementation
        /// </summary>
        /// <param name="dataRepository">The Data Repository</param>
        public StdLabelManagementServiceImpl(IDataRepository dataRepository)
        {
            try
            {
                _dataRepository = dataRepository;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Standard Label Management Service Implementation", caught);
                throw;
            }
        }

        /// <summary>
        /// Get All Labels
        /// </summary>
        /// <returns>The Labels</returns>
        public IEnumerable<DataContract.Metadata.Label> GetAllLabels()
        {
            try
            {
                var labels = _dataRepository.LabelRepository.GetAllLabels();
                var results = new List<DataContract.Metadata.Label>();
                labels.ToList().ForEach(l => results.Add(BuildLabelDataContract(l)));
                return results;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting All Labels", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Top Level Labels
        /// </summary>
        /// <returns>The Top Level Labels</returns>
        public IEnumerable<DataContract.Metadata.Label> GetTopLevelLabels()
        {
            try
            {
                var labels = _dataRepository.LabelRepository.GetTopLevelLabels();
                var results = new List<DataContract.Metadata.Label>();
                labels.ToList().ForEach(l => results.Add(BuildLabelDataContract(l)));
                return results;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Top Level Labels", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Child Labels
        /// </summary>
        /// <param name="parentLabel">The Parent Label</param>
        /// <returns></returns>
        public IEnumerable<DataContract.Metadata.Label> GetChildLabels(DataContract.Metadata.Label parentLabel)
        {
            try
            {
                if (parentLabel == null)
                {
                    throw new ArgumentNullException("parentLabel");
                }

                var labels = _dataRepository.LabelRepository.GetChildLabels(parentLabel.ID);
                var results = new List<DataContract.Metadata.Label>();
                labels.ToList().ForEach(l => results.Add(BuildLabelDataContract(l)));
                return results;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Child Labels", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Label
        /// </summary>
        /// <param name="label">The Label</param>
        /// <remarks>
        /// This should return the label as it's created.
        /// This would greatly simplify the service's usage, and make
        /// the UI much snappier.
        /// </remarks>
        public DataContract.Metadata.Label CreateLabel(DataContract.Metadata.Label label)
        {
            try
            {
                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }

                var newLabel = BuildLabelDataContract(_dataRepository.LabelRepository.CreateLabel(label.ParentID, label.Name));
                return newLabel;

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Label", caught);
                throw;
            }
        }

        /// <summary>
        /// Update Label
        /// </summary>
        /// <param name="label">The Label</param>
        public void UpdateLabel(DataContract.Metadata.Label label)
        {
            try
            {
                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }

                /*
                 * First need to lookup the label entity from the database, using the label ID
                 */
                var labelEntity = _dataRepository.LabelRepository.GetLabelByID(label.ID).FirstOrDefault();
                if (labelEntity == null)
                {
                    throw new ApplicationException("Label does not exist");
                }
                /*
                 * Then we update the entity accordingly and persist the changes
                 */
                labelEntity.ParentID = label.ParentID;
                labelEntity.Name = label.Name;
                _dataRepository.LabelRepository.UpdateLabel(labelEntity);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Updating Label", caught);
                throw;
            }
        }

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="label">The Label</param>
        public void DeleteLabel(DataContract.Metadata.Label label)
        {
            try
            {
                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }
                /*
                 * First need to lookup the label entity from the database
                 */
                var labelEntity = _dataRepository.LabelRepository.GetLabelByID(label.ID).FirstOrDefault();
                if (labelEntity == null)
                {
                    throw new ApplicationException("Label does not exist");
                }
                /*
                 * Then we just have to remove the label
                 */
                _dataRepository.LabelRepository.DeleteLabel(labelEntity);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Deleting Label", caught);
                throw;
            } 
        }

        #region [Data Contract Assembly Helpers]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelEntity"></param>
        /// <returns></returns>
        private DataContract.Metadata.Label BuildLabelDataContract(DataEntity.ILabel labelEntity)
        {
            try
            {
                if (labelEntity == null)
                {
                    throw new ArgumentNullException("labelEntity");
                }

                var label = new DataContract.Metadata.Label
                {
                    ID = labelEntity.ID,
                    ParentID = labelEntity.ParentID,
                    Name = labelEntity.Name
                };
                return label;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Building Label Data Contract", caught);
                throw;
            }
        }

        #endregion

    }
}
