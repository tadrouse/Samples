﻿using Umbraco.Core;
using Umbraco.Core.Persistence;
using AbleMods.Dto;

namespace AbleMods.Services
{
    /// <summary>
    /// The legacy data service.
    /// </summary>
    public class acProductDataService
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly Database _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="acProductDataService"/> class.
        /// </summary>
        public acProductDataService()
            : this(ApplicationContext.Current.DatabaseContext.Database)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="acProductDataService"/> class.
        /// </summary>
        /// <param name="database">
        /// The database.
        /// </param>
        public acProductDataService(Database database)
        {
            _database = database;
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="dto">
        /// The dto.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddOrUpdate(AcProductDto dto)
        {
            bool retVal;
            if (dto.Id > 0)
            {
                retVal = _database.Update(dto) > 0;
            }
            else
            {
                var result = (decimal)_database.Insert(dto);
                retVal = result > 0;
            }

            return retVal;
        }
    }
}