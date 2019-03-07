namespace React.Json.Infra.Repositories
{
    public partial class TemplateRepository
    {
        #region SELECT Template
        
            #region QuerySelectById
            private const string QuerySelectById = @"SELECT * FROM Template where Id = @Id";
            #endregion

            #region QuerySelectAll
            private const string QuerySelectAll = @"";
            #endregion

            #region QuerySelectAllGrid
            private const string QuerySelectAllGrid = @"";
            #endregion

        #endregion

        #region INSERT's

         #region QueryInsert
            private const string QueryInsert = @"";
            #endregion

        #endregion
		
		#region UPDATE's
        
            #region QueryUpdate
            private const string QueryUpdate = @"";
            #endregion

        #endregion
		
		#region DELETE's
       
            #region QueryDelete
            private const string QueryDelete = @"";
            #endregion

        #endregion
    }
}
