using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using System.Security;
using System.Data;
using Luval.FormExtractor.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace Luval.FormExtractor.Activities
{
    [LocalizedDisplayName(nameof(Resources.FormExtraction_DisplayName))]
    [LocalizedDescription(nameof(Resources.FormExtraction_Description))]
    public class FormExtraction : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.FormExtraction_FileName_DisplayName))]
        [LocalizedDescription(nameof(Resources.FormExtraction_FileName_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FileName { get; set; }

        [LocalizedDisplayName(nameof(Resources.FormExtraction_JsonConfiguration_DisplayName))]
        [LocalizedDescription(nameof(Resources.FormExtraction_JsonConfiguration_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> JsonConfiguration { get; set; }

        [LocalizedDisplayName(nameof(Resources.FormExtraction_APIKey_DisplayName))]
        [LocalizedDescription(nameof(Resources.FormExtraction_APIKey_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<SecureString> APIKey { get; set; }

        [LocalizedDisplayName(nameof(Resources.FormExtraction_Results_DisplayName))]
        [LocalizedDescription(nameof(Resources.FormExtraction_Results_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<DataTable> Results { get; set; }

        #endregion


        #region Constructors

        public FormExtraction()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (FileName == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FileName)));
            if (JsonConfiguration == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(JsonConfiguration)));
            if (APIKey == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(APIKey)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var fileName = FileName.Get(context);
            var jsonConfiguration = JsonConfiguration.Get(context);
            var apiKey = APIKey.Get(context);

            var extractorHelper = new ExtractorHelper();
            var dtResult = extractorHelper.DoExtraction(apiKey, fileName, jsonConfiguration);

            // Outputs
            return (ctx) => {
                Results.Set(ctx, dtResult);
            };
        }

        #endregion
    }
}

