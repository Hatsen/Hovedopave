﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminModule.Webservice {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Webservice.DB")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AdminModule.Webservice.Student))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AdminModule.Webservice.Teacher))]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BirthdateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastloginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserroleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Birthdate {
            get {
                return this.BirthdateField;
            }
            set {
                if ((object.ReferenceEquals(this.BirthdateField, value) != true)) {
                    this.BirthdateField = value;
                    this.RaisePropertyChanged("Birthdate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Firstname {
            get {
                return this.FirstnameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstnameField, value) != true)) {
                    this.FirstnameField = value;
                    this.RaisePropertyChanged("Firstname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Lastlogin {
            get {
                return this.LastloginField;
            }
            set {
                if ((this.LastloginField.Equals(value) != true)) {
                    this.LastloginField = value;
                    this.RaisePropertyChanged("Lastlogin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Lastname {
            get {
                return this.LastnameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastnameField, value) != true)) {
                    this.LastnameField = value;
                    this.RaisePropertyChanged("Lastname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Userrole {
            get {
                return this.UserroleField;
            }
            set {
                if ((this.UserroleField.Equals(value) != true)) {
                    this.UserroleField = value;
                    this.RaisePropertyChanged("Userrole");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Student", Namespace="http://schemas.datacontract.org/2004/07/Webservice.DB")]
    [System.SerializableAttribute()]
    public partial class Student : AdminModule.Webservice.User {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FkClassidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FkuseridField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FkClassid {
            get {
                return this.FkClassidField;
            }
            set {
                if ((this.FkClassidField.Equals(value) != true)) {
                    this.FkClassidField = value;
                    this.RaisePropertyChanged("FkClassid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Fkuserid {
            get {
                return this.FkuseridField;
            }
            set {
                if ((this.FkuseridField.Equals(value) != true)) {
                    this.FkuseridField = value;
                    this.RaisePropertyChanged("Fkuserid");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Teacher", Namespace="http://schemas.datacontract.org/2004/07/Webservice.DB")]
    [System.SerializableAttribute()]
    public partial class Teacher : AdminModule.Webservice.User {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FkuseridField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Fkuserid {
            get {
                return this.FkuseridField;
            }
            set {
                if ((this.FkuseridField.Equals(value) != true)) {
                    this.FkuseridField = value;
                    this.RaisePropertyChanged("Fkuserid");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Webservice.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLoginDetails", ReplyAction="http://tempuri.org/IService1/GetLoginDetailsResponse")]
        bool GetLoginDetails(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetLoginDetails", ReplyAction="http://tempuri.org/IService1/GetLoginDetailsResponse")]
        System.IAsyncResult BeginGetLoginDetails(string username, string password, System.AsyncCallback callback, object asyncState);
        
        bool EndGetLoginDetails(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateTeacher", ReplyAction="http://tempuri.org/IService1/CreateTeacherResponse")]
        bool CreateTeacher();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/CreateTeacher", ReplyAction="http://tempuri.org/IService1/CreateTeacherResponse")]
        System.IAsyncResult BeginCreateTeacher(System.AsyncCallback callback, object asyncState);
        
        bool EndCreateTeacher(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTeacher", ReplyAction="http://tempuri.org/IService1/GetTeacherResponse")]
        AdminModule.Webservice.Teacher GetTeacher();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetTeacher", ReplyAction="http://tempuri.org/IService1/GetTeacherResponse")]
        System.IAsyncResult BeginGetTeacher(System.AsyncCallback callback, object asyncState);
        
        AdminModule.Webservice.Teacher EndGetTeacher(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTeachers", ReplyAction="http://tempuri.org/IService1/GetTeachersResponse")]
        System.Collections.Generic.List<AdminModule.Webservice.Teacher> GetTeachers();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetTeachers", ReplyAction="http://tempuri.org/IService1/GetTeachersResponse")]
        System.IAsyncResult BeginGetTeachers(System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<AdminModule.Webservice.Teacher> EndGetTeachers(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStudents", ReplyAction="http://tempuri.org/IService1/GetStudentsResponse")]
        System.Collections.Generic.List<AdminModule.Webservice.Student> GetStudents();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetStudents", ReplyAction="http://tempuri.org/IService1/GetStudentsResponse")]
        System.IAsyncResult BeginGetStudents(System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<AdminModule.Webservice.Student> EndGetStudents(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserCount", ReplyAction="http://tempuri.org/IService1/GetUserCountResponse")]
        int GetUserCount();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetUserCount", ReplyAction="http://tempuri.org/IService1/GetUserCountResponse")]
        System.IAsyncResult BeginGetUserCount(System.AsyncCallback callback, object asyncState);
        
        int EndGetUserCount(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : AdminModule.Webservice.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetLoginDetailsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetLoginDetailsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateTeacherCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CreateTeacherCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetTeacherCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetTeacherCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public AdminModule.Webservice.Teacher Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((AdminModule.Webservice.Teacher)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetTeachersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetTeachersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.Generic.List<AdminModule.Webservice.Teacher> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.Generic.List<AdminModule.Webservice.Teacher>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetStudentsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetStudentsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.Generic.List<AdminModule.Webservice.Student> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.Generic.List<AdminModule.Webservice.Student>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetUserCountCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetUserCountCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<AdminModule.Webservice.IService1>, AdminModule.Webservice.IService1 {
        
        private BeginOperationDelegate onBeginGetLoginDetailsDelegate;
        
        private EndOperationDelegate onEndGetLoginDetailsDelegate;
        
        private System.Threading.SendOrPostCallback onGetLoginDetailsCompletedDelegate;
        
        private BeginOperationDelegate onBeginCreateTeacherDelegate;
        
        private EndOperationDelegate onEndCreateTeacherDelegate;
        
        private System.Threading.SendOrPostCallback onCreateTeacherCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetTeacherDelegate;
        
        private EndOperationDelegate onEndGetTeacherDelegate;
        
        private System.Threading.SendOrPostCallback onGetTeacherCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetTeachersDelegate;
        
        private EndOperationDelegate onEndGetTeachersDelegate;
        
        private System.Threading.SendOrPostCallback onGetTeachersCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetStudentsDelegate;
        
        private EndOperationDelegate onEndGetStudentsDelegate;
        
        private System.Threading.SendOrPostCallback onGetStudentsCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetUserCountDelegate;
        
        private EndOperationDelegate onEndGetUserCountDelegate;
        
        private System.Threading.SendOrPostCallback onGetUserCountCompletedDelegate;
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<GetLoginDetailsCompletedEventArgs> GetLoginDetailsCompleted;
        
        public event System.EventHandler<CreateTeacherCompletedEventArgs> CreateTeacherCompleted;
        
        public event System.EventHandler<GetTeacherCompletedEventArgs> GetTeacherCompleted;
        
        public event System.EventHandler<GetTeachersCompletedEventArgs> GetTeachersCompleted;
        
        public event System.EventHandler<GetStudentsCompletedEventArgs> GetStudentsCompleted;
        
        public event System.EventHandler<GetUserCountCompletedEventArgs> GetUserCountCompleted;
        
        public bool GetLoginDetails(string username, string password) {
            return base.Channel.GetLoginDetails(username, password);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetLoginDetails(string username, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetLoginDetails(username, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndGetLoginDetails(System.IAsyncResult result) {
            return base.Channel.EndGetLoginDetails(result);
        }
        
        private System.IAsyncResult OnBeginGetLoginDetails(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string username = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return this.BeginGetLoginDetails(username, password, callback, asyncState);
        }
        
        private object[] OnEndGetLoginDetails(System.IAsyncResult result) {
            bool retVal = this.EndGetLoginDetails(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetLoginDetailsCompleted(object state) {
            if ((this.GetLoginDetailsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetLoginDetailsCompleted(this, new GetLoginDetailsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetLoginDetailsAsync(string username, string password) {
            this.GetLoginDetailsAsync(username, password, null);
        }
        
        public void GetLoginDetailsAsync(string username, string password, object userState) {
            if ((this.onBeginGetLoginDetailsDelegate == null)) {
                this.onBeginGetLoginDetailsDelegate = new BeginOperationDelegate(this.OnBeginGetLoginDetails);
            }
            if ((this.onEndGetLoginDetailsDelegate == null)) {
                this.onEndGetLoginDetailsDelegate = new EndOperationDelegate(this.OnEndGetLoginDetails);
            }
            if ((this.onGetLoginDetailsCompletedDelegate == null)) {
                this.onGetLoginDetailsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetLoginDetailsCompleted);
            }
            base.InvokeAsync(this.onBeginGetLoginDetailsDelegate, new object[] {
                        username,
                        password}, this.onEndGetLoginDetailsDelegate, this.onGetLoginDetailsCompletedDelegate, userState);
        }
        
        public bool CreateTeacher() {
            return base.Channel.CreateTeacher();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCreateTeacher(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreateTeacher(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndCreateTeacher(System.IAsyncResult result) {
            return base.Channel.EndCreateTeacher(result);
        }
        
        private System.IAsyncResult OnBeginCreateTeacher(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginCreateTeacher(callback, asyncState);
        }
        
        private object[] OnEndCreateTeacher(System.IAsyncResult result) {
            bool retVal = this.EndCreateTeacher(result);
            return new object[] {
                    retVal};
        }
        
        private void OnCreateTeacherCompleted(object state) {
            if ((this.CreateTeacherCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateTeacherCompleted(this, new CreateTeacherCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateTeacherAsync() {
            this.CreateTeacherAsync(null);
        }
        
        public void CreateTeacherAsync(object userState) {
            if ((this.onBeginCreateTeacherDelegate == null)) {
                this.onBeginCreateTeacherDelegate = new BeginOperationDelegate(this.OnBeginCreateTeacher);
            }
            if ((this.onEndCreateTeacherDelegate == null)) {
                this.onEndCreateTeacherDelegate = new EndOperationDelegate(this.OnEndCreateTeacher);
            }
            if ((this.onCreateTeacherCompletedDelegate == null)) {
                this.onCreateTeacherCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateTeacherCompleted);
            }
            base.InvokeAsync(this.onBeginCreateTeacherDelegate, null, this.onEndCreateTeacherDelegate, this.onCreateTeacherCompletedDelegate, userState);
        }
        
        public AdminModule.Webservice.Teacher GetTeacher() {
            return base.Channel.GetTeacher();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetTeacher(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetTeacher(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public AdminModule.Webservice.Teacher EndGetTeacher(System.IAsyncResult result) {
            return base.Channel.EndGetTeacher(result);
        }
        
        private System.IAsyncResult OnBeginGetTeacher(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetTeacher(callback, asyncState);
        }
        
        private object[] OnEndGetTeacher(System.IAsyncResult result) {
            AdminModule.Webservice.Teacher retVal = this.EndGetTeacher(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetTeacherCompleted(object state) {
            if ((this.GetTeacherCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetTeacherCompleted(this, new GetTeacherCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetTeacherAsync() {
            this.GetTeacherAsync(null);
        }
        
        public void GetTeacherAsync(object userState) {
            if ((this.onBeginGetTeacherDelegate == null)) {
                this.onBeginGetTeacherDelegate = new BeginOperationDelegate(this.OnBeginGetTeacher);
            }
            if ((this.onEndGetTeacherDelegate == null)) {
                this.onEndGetTeacherDelegate = new EndOperationDelegate(this.OnEndGetTeacher);
            }
            if ((this.onGetTeacherCompletedDelegate == null)) {
                this.onGetTeacherCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTeacherCompleted);
            }
            base.InvokeAsync(this.onBeginGetTeacherDelegate, null, this.onEndGetTeacherDelegate, this.onGetTeacherCompletedDelegate, userState);
        }
        
        public System.Collections.Generic.List<AdminModule.Webservice.Teacher> GetTeachers() {
            return base.Channel.GetTeachers();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetTeachers(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetTeachers(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<AdminModule.Webservice.Teacher> EndGetTeachers(System.IAsyncResult result) {
            return base.Channel.EndGetTeachers(result);
        }
        
        private System.IAsyncResult OnBeginGetTeachers(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetTeachers(callback, asyncState);
        }
        
        private object[] OnEndGetTeachers(System.IAsyncResult result) {
            System.Collections.Generic.List<AdminModule.Webservice.Teacher> retVal = this.EndGetTeachers(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetTeachersCompleted(object state) {
            if ((this.GetTeachersCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetTeachersCompleted(this, new GetTeachersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetTeachersAsync() {
            this.GetTeachersAsync(null);
        }
        
        public void GetTeachersAsync(object userState) {
            if ((this.onBeginGetTeachersDelegate == null)) {
                this.onBeginGetTeachersDelegate = new BeginOperationDelegate(this.OnBeginGetTeachers);
            }
            if ((this.onEndGetTeachersDelegate == null)) {
                this.onEndGetTeachersDelegate = new EndOperationDelegate(this.OnEndGetTeachers);
            }
            if ((this.onGetTeachersCompletedDelegate == null)) {
                this.onGetTeachersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTeachersCompleted);
            }
            base.InvokeAsync(this.onBeginGetTeachersDelegate, null, this.onEndGetTeachersDelegate, this.onGetTeachersCompletedDelegate, userState);
        }
        
        public System.Collections.Generic.List<AdminModule.Webservice.Student> GetStudents() {
            return base.Channel.GetStudents();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetStudents(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetStudents(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<AdminModule.Webservice.Student> EndGetStudents(System.IAsyncResult result) {
            return base.Channel.EndGetStudents(result);
        }
        
        private System.IAsyncResult OnBeginGetStudents(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetStudents(callback, asyncState);
        }
        
        private object[] OnEndGetStudents(System.IAsyncResult result) {
            System.Collections.Generic.List<AdminModule.Webservice.Student> retVal = this.EndGetStudents(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetStudentsCompleted(object state) {
            if ((this.GetStudentsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetStudentsCompleted(this, new GetStudentsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetStudentsAsync() {
            this.GetStudentsAsync(null);
        }
        
        public void GetStudentsAsync(object userState) {
            if ((this.onBeginGetStudentsDelegate == null)) {
                this.onBeginGetStudentsDelegate = new BeginOperationDelegate(this.OnBeginGetStudents);
            }
            if ((this.onEndGetStudentsDelegate == null)) {
                this.onEndGetStudentsDelegate = new EndOperationDelegate(this.OnEndGetStudents);
            }
            if ((this.onGetStudentsCompletedDelegate == null)) {
                this.onGetStudentsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetStudentsCompleted);
            }
            base.InvokeAsync(this.onBeginGetStudentsDelegate, null, this.onEndGetStudentsDelegate, this.onGetStudentsCompletedDelegate, userState);
        }
        
        public int GetUserCount() {
            return base.Channel.GetUserCount();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetUserCount(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUserCount(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public int EndGetUserCount(System.IAsyncResult result) {
            return base.Channel.EndGetUserCount(result);
        }
        
        private System.IAsyncResult OnBeginGetUserCount(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetUserCount(callback, asyncState);
        }
        
        private object[] OnEndGetUserCount(System.IAsyncResult result) {
            int retVal = this.EndGetUserCount(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetUserCountCompleted(object state) {
            if ((this.GetUserCountCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUserCountCompleted(this, new GetUserCountCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUserCountAsync() {
            this.GetUserCountAsync(null);
        }
        
        public void GetUserCountAsync(object userState) {
            if ((this.onBeginGetUserCountDelegate == null)) {
                this.onBeginGetUserCountDelegate = new BeginOperationDelegate(this.OnBeginGetUserCount);
            }
            if ((this.onEndGetUserCountDelegate == null)) {
                this.onEndGetUserCountDelegate = new EndOperationDelegate(this.OnEndGetUserCount);
            }
            if ((this.onGetUserCountCompletedDelegate == null)) {
                this.onGetUserCountCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUserCountCompleted);
            }
            base.InvokeAsync(this.onBeginGetUserCountDelegate, null, this.onEndGetUserCountDelegate, this.onGetUserCountCompletedDelegate, userState);
        }
    }
}
