// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSHFStandardLibrary.Core.Codes;
using FSHFStandardLibrary.Core.Downloader.General;
using FSHFStandardLibrary.Core.Downloader.Specific;
using FSHFStandardLibrary.Implementations.Downloader.Specific;

#endregion

namespace FSHFStandardLibrary.Implementations.Downloader.General
{
    public class StandardUrlDownloader : IDownloader<DownloadResult<string>,
        UrlDownloadRequest>
    {
        #region Implementation of IDownloader<DownloadResult<string>,UrlDownloadRequest>

        /// <inheritdoc />
        public Task<List<DownloadResult<string>>> DownloadForManyRequestsAsync(
            IEnumerable<UrlDownloadRequest> downloadRequests)
        {
            List<UrlDownloadRequestWithIcaoCode> requestsWithIcao = downloadRequests
                .Select(x => new UrlDownloadRequestWithIcaoCode(x.Url, new IcaoCode("NONE")))
                .ToList();

            return Task.Run(async () =>
            {
                return (await new StandardUrlDownloaderWithIcaoCode().DownloadForManyRequestsAsync(requestsWithIcao))
                    .Select(x => new DownloadResult<string>(x.DownloadedData, x.DownloadingTime, x.ResponseCode))
                    .ToList();
            });
        }

        #endregion
    }
}