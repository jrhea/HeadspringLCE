﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeDirectory.EmployeeServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceRef.IEmployeeService")]
    public interface IEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeService/GetAllEmployeesResponse")]
        System.Collections.Generic.List<EmployeeData.IEmployee> GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeService/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<EmployeeData.IEmployee>> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployee", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(EmployeeData.Employee))]
        EmployeeData.IEmployee GetEmployee(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployee", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeResponse")]
        System.Threading.Tasks.Task<EmployeeData.IEmployee> GetEmployeeAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllRoles", ReplyAction="http://tempuri.org/IEmployeeService/GetAllRolesResponse")]
        System.Collections.Generic.List<EmployeeData.Role> GetAllRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllRoles", ReplyAction="http://tempuri.org/IEmployeeService/GetAllRolesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<EmployeeData.Role>> GetAllRolesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/CreateEmployeeResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(EmployeeData.Employee))]
        void CreateEmployee(EmployeeData.IEmployee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/CreateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/CreateEmployeeResponse")]
        System.Threading.Tasks.Task CreateEmployeeAsync(EmployeeData.IEmployee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/UpdateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/UpdateEmployeeResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(EmployeeData.Employee))]
        void UpdateEmployee(EmployeeData.IEmployee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/UpdateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/UpdateEmployeeResponse")]
        System.Threading.Tasks.Task UpdateEmployeeAsync(EmployeeData.IEmployee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/DeleteEmployee", ReplyAction="http://tempuri.org/IEmployeeService/DeleteEmployeeResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(EmployeeData.Employee))]
        void DeleteEmployee(EmployeeData.IEmployee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/DeleteEmployee", ReplyAction="http://tempuri.org/IEmployeeService/DeleteEmployeeResponse")]
        System.Threading.Tasks.Task DeleteEmployeeAsync(EmployeeData.IEmployee employee);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeServiceChannel : EmployeeDirectory.EmployeeServiceRef.IEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceClient : System.ServiceModel.ClientBase<EmployeeDirectory.EmployeeServiceRef.IEmployeeService>, EmployeeDirectory.EmployeeServiceRef.IEmployeeService {
        
        public EmployeeServiceClient() {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<EmployeeData.IEmployee> GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<EmployeeData.IEmployee>> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public EmployeeData.IEmployee GetEmployee(int id) {
            return base.Channel.GetEmployee(id);
        }
        
        public System.Threading.Tasks.Task<EmployeeData.IEmployee> GetEmployeeAsync(int id) {
            return base.Channel.GetEmployeeAsync(id);
        }
        
        public System.Collections.Generic.List<EmployeeData.Role> GetAllRoles() {
            return base.Channel.GetAllRoles();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<EmployeeData.Role>> GetAllRolesAsync() {
            return base.Channel.GetAllRolesAsync();
        }
        
        public void CreateEmployee(EmployeeData.IEmployee employee) {
            base.Channel.CreateEmployee(employee);
        }
        
        public System.Threading.Tasks.Task CreateEmployeeAsync(EmployeeData.IEmployee employee) {
            return base.Channel.CreateEmployeeAsync(employee);
        }
        
        public void UpdateEmployee(EmployeeData.IEmployee employee) {
            base.Channel.UpdateEmployee(employee);
        }
        
        public System.Threading.Tasks.Task UpdateEmployeeAsync(EmployeeData.IEmployee employee) {
            return base.Channel.UpdateEmployeeAsync(employee);
        }
        
        public void DeleteEmployee(EmployeeData.IEmployee employee) {
            base.Channel.DeleteEmployee(employee);
        }
        
        public System.Threading.Tasks.Task DeleteEmployeeAsync(EmployeeData.IEmployee employee) {
            return base.Channel.DeleteEmployeeAsync(employee);
        }
    }
}