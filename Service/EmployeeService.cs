﻿using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;   
        }

        public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges)
        {            
            var employeeList = _repository.Employee.GetEmployeesByProjectId(projectId, trackChanges);
            var result = _mapper.Map<IEnumerable<EmployeeDto>>(employeeList);
            return result;        
        }

        public EmployeeDto GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChanges)
        {
            var employee = _repository.Employee.GetEmployeeByProjectId(projectId, employeeId, trackChanges);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }
    }
}
