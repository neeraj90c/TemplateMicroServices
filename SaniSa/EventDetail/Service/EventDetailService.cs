using Common.Service;
using EventDetail.DTO;
using EventDetail.Interface;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.ComponentModel.Design;
using MediatR;

namespace EventDetail.Service
{
    public class EventDetailService : DABase, IEventDetail
    {
        private const string SP_EventDetail_Create = "EventDetail_Create";
        private const string SP_EventDetail_Update = "EventDetail_Update";
        private const string SP_EventDetail_Delete = "EventDetail_Delete";
        private const string SP_EventDetail_ReadAll = "EventDetail_ReadAll";
        private const string SP_EventDetail_ReadByEDetailId = "EventDetail_ReadByEDetailId";
        private const string SP_EventDetail_ReadByEventId = "EventDetail_ReadByEventId";


        private ILogger<EventDetailService> _logger;
        public EventDetailService(IOptions<ConnectionSettings> connectionSettings, ILogger<EventDetailService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<EventDetailResponseDTO> Create(EventDetailCreateRequestDTO request)
        {
            EventDetailResponseDTO response = new EventDetailResponseDTO();
            _logger.LogInformation($"Started Event Detail Create {request.EventId}  and ItemId: {request.ItemId}");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response = await connection.QuerySingleAsync<EventDetailResponseDTO>(SP_EventDetail_Create, new
                    {
                        EventId    = request.EventId,
                        ItemId   =  request.ItemId,
                        CompanyId = request.CompanyId,
                        ActionUser = request.ActionUser,
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

        public async Task<EventDetailResponseDTO> Delete(EventDetailDeleteRequestDTO request)
        {
            EventDetailResponseDTO response = new EventDetailResponseDTO();
            _logger.LogInformation($"Started Event Detail Delete for EventDetailId : {request.EDetailId} ");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response = await connection.QuerySingleAsync<EventDetailResponseDTO>(SP_EventDetail_Delete, new
                    {
                        EDetailId = request.EDetailId,
                        ActionUser = request.ActionUser,
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

        public async Task<EventDetailList> ReadAll()
        {
            EventDetailList response = new EventDetailList();
            _logger.LogInformation($"Started Fetching Event Detail List ");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response.EventList = await connection.QueryAsync<EventDetailResponseDTO>(SP_EventDetail_ReadAll, new
                    {
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

        public async Task<EventDetailList> ReadByEventId(EventdetailReadByEventIdRequestDTO request)
        {
            EventDetailList response = new EventDetailList();
            _logger.LogInformation($"Started Fetching Event Detail List by EventId : {request.EventId} ");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response.EventList = await connection.QueryAsync<EventDetailResponseDTO>(SP_EventDetail_ReadByEventId, new
                    {
                        EventId = request.EventId
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

        public async Task<EventDetailResponseDTO> ReadById(EventDetailReadByIdRequestDTO request)
        {
            EventDetailResponseDTO response = new EventDetailResponseDTO();
            _logger.LogInformation($"Started Fetching Event Details By EventDetailId {request.EDetailId} ");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response = await connection.QuerySingleAsync<EventDetailResponseDTO>(SP_EventDetail_ReadByEDetailId, new
                    {
                        EDetailId = request.EDetailId
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

        public async Task<EventDetailResponseDTO> Update(EventDetailUpdateRequestDTO request)
        {
            EventDetailResponseDTO response = new EventDetailResponseDTO();
            _logger.LogInformation($"Started Updating Event Detail for EventDetailId {request.EDetailId} ");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response = await connection.QuerySingleAsync<EventDetailResponseDTO>(SP_EventDetail_Update, new
                    {
                        EDetailId = request.EDetailId,
                        EventId = request.EventId,
                        ItemId = request.ItemId,
                        IsActive = request.IsActive,
                        ActionUser = request.ActionUser,
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }
    }
}
