using Common.Service;
using EventMaster.DTO;
using EventMaster.Interface;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using System.ComponentModel.Design;
using MediatR;

namespace EventMaster.Service
{
    public class EventMasterService : DABase, IEventMaster
    {
        private const string SP_EventMaster_Create = "EventMaster_Create";
        private const string SP_EventMaster_Update = "EventMaster_Update";
        private const string SP_EventMaster_Delete = "EventMaster_Delete";
        private const string SP_EventMaster_ReadAll = "EventMaster_ReadAll";
        private const string SP_EventMaster_ReadByEventId = "EventMaster_ReadByEventId";
        private ILogger<EventMasterService> _logger;
        public EventMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<EventMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<EventMasterResponseDTO> Create(EventMasterCreateRequestDTO request)
        {
            EventMasterResponseDTO response = new EventMasterResponseDTO();
            _logger.LogInformation($"Started Event Master Create {request.EventName}  for desc: {request.EventDesc}");
            
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response = await connection.QuerySingleAsync<EventMasterResponseDTO>(SP_EventMaster_Create, new
                    {
                        EventName  = request.EventName,
                        EventCode  = request.EventCode,
                        EventDesc  = request.EventDesc,
                        CompanyId  = request.CompanyId,
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
        public async Task<EventMasterResponseDTO> Update(EventMasterUpdateRequestDTO request)
        {
            EventMasterResponseDTO response = new EventMasterResponseDTO();
            _logger.LogInformation($"Started Event Master Update {request.EventName}  for desc: {request.EventDesc}");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response = await connection.QuerySingleAsync<EventMasterResponseDTO>(SP_EventMaster_Update, new
                    {
                        EventId = request.EventId,
                        EventName = request.EventName,
                        EventCode = request.EventCode,
                        EventDesc = request.EventDesc,
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
        public async Task<EventMasterResponseDTO> Delete(EventMasterDeleteRequestDTO request)
        {
            EventMasterResponseDTO response = new EventMasterResponseDTO();
            _logger.LogInformation($"Started Event Master Delete for EventId: {request.EventId}");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response = await connection.QuerySingleAsync<EventMasterResponseDTO>(SP_EventMaster_Delete, new
                    {
                        EventId = request.EventId,
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
        public async Task<EventList> ReadAll()
        {
            EventList response = new EventList();
            _logger.LogInformation($"Started Fetching all Events ");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response.List = await connection.QueryAsync<EventMasterResponseDTO>(SP_EventMaster_ReadAll, new
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
        public async Task<EventMasterResponseDTO> ReadByEventId(EventMasterReadByEventIdRequestDTO request)
        {
            EventMasterResponseDTO response = new EventMasterResponseDTO();
            _logger.LogInformation($"Started Feching Event Details by EventId {request.EventId}");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response = await connection.QuerySingleAsync<EventMasterResponseDTO>(SP_EventMaster_ReadByEventId, new
                    {
                        EventId = request.EventId,
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
