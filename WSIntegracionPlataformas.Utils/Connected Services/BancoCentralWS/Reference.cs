﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSIntegracionPlataformas.Utils.BancoCentralWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://bancocentral.org/", ConfigurationName="BancoCentralWS.SieteWSSoap")]
    public interface SieteWSSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bancocentral.org/SearchSeries", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(abstractBaseObject))]
        WSIntegracionPlataformas.Utils.BancoCentralWS.Respuesta SearchSeries(string user, string password, string frequencyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bancocentral.org/SearchSeries", ReplyAction="*")]
        System.Threading.Tasks.Task<WSIntegracionPlataformas.Utils.BancoCentralWS.Respuesta> SearchSeriesAsync(string user, string password, string frequencyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bancocentral.org/GetSeries", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(abstractBaseObject))]
        WSIntegracionPlataformas.Utils.BancoCentralWS.Respuesta GetSeries(string user, string password, string firstDate, string lastDate, string[] seriesIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bancocentral.org/GetSeries", ReplyAction="*")]
        System.Threading.Tasks.Task<WSIntegracionPlataformas.Utils.BancoCentralWS.Respuesta> GetSeriesAsync(string user, string password, string firstDate, string lastDate, string[] seriesIds);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bancocentral.org/")]
    public partial class Respuesta : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int codigoField;
        
        private string descripcionField;
        
        private fameSeries[] seriesField;
        
        private internetSeriesInfo[] seriesInfosField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
                this.RaisePropertyChanged("Codigo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("Descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=2)]
        public fameSeries[] Series {
            get {
                return this.seriesField;
            }
            set {
                this.seriesField = value;
                this.RaisePropertyChanged("Series");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        public internetSeriesInfo[] SeriesInfos {
            get {
                return this.seriesInfosField;
            }
            set {
                this.seriesInfosField = value;
                this.RaisePropertyChanged("SeriesInfos");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://web.service.sdmx.sdms.sungard.com/")]
    public partial class fameSeries : fameNode {
        
        private seriesKey seriesKeyField;
        
        private int precisionField;
        
        private obs[] obsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public seriesKey seriesKey {
            get {
                return this.seriesKeyField;
            }
            set {
                this.seriesKeyField = value;
                this.RaisePropertyChanged("seriesKey");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int precision {
            get {
                return this.precisionField;
            }
            set {
                this.precisionField = value;
                this.RaisePropertyChanged("precision");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("obs", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=2)]
        public obs[] obs {
            get {
                return this.obsField;
            }
            set {
                this.obsField = value;
                this.RaisePropertyChanged("obs");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://web.service.sdmx.sdms.sungard.com/")]
    public partial class seriesKey : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string keyFamilyIdField;
        
        private System.DateTime lastModifiedField;
        
        private bool lastModifiedFieldSpecified;
        
        private string lastModifiedUserField;
        
        private string seriesIdField;
        
        private string dataStageField;
        
        private bool existsField;
        
        private string descriptionField;
        
        private string descripIngField;
        
        private string descripEspField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string keyFamilyId {
            get {
                return this.keyFamilyIdField;
            }
            set {
                this.keyFamilyIdField = value;
                this.RaisePropertyChanged("keyFamilyId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public System.DateTime lastModified {
            get {
                return this.lastModifiedField;
            }
            set {
                this.lastModifiedField = value;
                this.RaisePropertyChanged("lastModified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lastModifiedSpecified {
            get {
                return this.lastModifiedFieldSpecified;
            }
            set {
                this.lastModifiedFieldSpecified = value;
                this.RaisePropertyChanged("lastModifiedSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string lastModifiedUser {
            get {
                return this.lastModifiedUserField;
            }
            set {
                this.lastModifiedUserField = value;
                this.RaisePropertyChanged("lastModifiedUser");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string seriesId {
            get {
                return this.seriesIdField;
            }
            set {
                this.seriesIdField = value;
                this.RaisePropertyChanged("seriesId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string dataStage {
            get {
                return this.dataStageField;
            }
            set {
                this.dataStageField = value;
                this.RaisePropertyChanged("dataStage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public bool exists {
            get {
                return this.existsField;
            }
            set {
                this.existsField = value;
                this.RaisePropertyChanged("exists");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public string descripIng {
            get {
                return this.descripIngField;
            }
            set {
                this.descripIngField = value;
                this.RaisePropertyChanged("descripIng");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public string descripEsp {
            get {
                return this.descripEspField;
            }
            set {
                this.descripEspField = value;
                this.RaisePropertyChanged("descripEsp");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://web.service.sdmx.sdms.sungard.com/")]
    public partial class internetSeriesInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string seriesIdField;
        
        private frequency frequencyField;
        
        private bool frequencyFieldSpecified;
        
        private string frequencyCodeField;
        
        private observed observedField;
        
        private bool observedFieldSpecified;
        
        private string observedCodeField;
        
        private string spanishTitleField;
        
        private string englishTitleField;
        
        private string firstObservationField;
        
        private string lastObservationField;
        
        private string updatedAtField;
        
        private string createdAtField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string seriesId {
            get {
                return this.seriesIdField;
            }
            set {
                this.seriesIdField = value;
                this.RaisePropertyChanged("seriesId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public frequency frequency {
            get {
                return this.frequencyField;
            }
            set {
                this.frequencyField = value;
                this.RaisePropertyChanged("frequency");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool frequencySpecified {
            get {
                return this.frequencyFieldSpecified;
            }
            set {
                this.frequencyFieldSpecified = value;
                this.RaisePropertyChanged("frequencySpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string frequencyCode {
            get {
                return this.frequencyCodeField;
            }
            set {
                this.frequencyCodeField = value;
                this.RaisePropertyChanged("frequencyCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public observed observed {
            get {
                return this.observedField;
            }
            set {
                this.observedField = value;
                this.RaisePropertyChanged("observed");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool observedSpecified {
            get {
                return this.observedFieldSpecified;
            }
            set {
                this.observedFieldSpecified = value;
                this.RaisePropertyChanged("observedSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string observedCode {
            get {
                return this.observedCodeField;
            }
            set {
                this.observedCodeField = value;
                this.RaisePropertyChanged("observedCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string spanishTitle {
            get {
                return this.spanishTitleField;
            }
            set {
                this.spanishTitleField = value;
                this.RaisePropertyChanged("spanishTitle");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string englishTitle {
            get {
                return this.englishTitleField;
            }
            set {
                this.englishTitleField = value;
                this.RaisePropertyChanged("englishTitle");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public string firstObservation {
            get {
                return this.firstObservationField;
            }
            set {
                this.firstObservationField = value;
                this.RaisePropertyChanged("firstObservation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public string lastObservation {
            get {
                return this.lastObservationField;
            }
            set {
                this.lastObservationField = value;
                this.RaisePropertyChanged("lastObservation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public string updatedAt {
            get {
                return this.updatedAtField;
            }
            set {
                this.updatedAtField = value;
                this.RaisePropertyChanged("updatedAt");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=10)]
        public string createdAt {
            get {
                return this.createdAtField;
            }
            set {
                this.createdAtField = value;
                this.RaisePropertyChanged("createdAt");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://web.service.sdmx.sdms.sungard.com/")]
    public enum frequency {
        
        /// <remarks/>
        UNDEFINED,
        
        /// <remarks/>
        SEMIANNUAL,
        
        /// <remarks/>
        WEEKLY,
        
        /// <remarks/>
        QUARTERLY,
        
        /// <remarks/>
        MONTHLY,
        
        /// <remarks/>
        ANNUAL,
        
        /// <remarks/>
        DAILY,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://web.service.sdmx.sdms.sungard.com/")]
    public enum observed {
        
        /// <remarks/>
        UNDEFINED,
        
        /// <remarks/>
        SUMMED,
        
        /// <remarks/>
        LOW,
        
        /// <remarks/>
        HIGH,
        
        /// <remarks/>
        END,
        
        /// <remarks/>
        BEGINNING,
        
        /// <remarks/>
        AVERAGED,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://web.service.sdmx.sdms.sungard.com/")]
    public partial class obs : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string indexDateStringField;
        
        private seriesKey seriesKeyField;
        
        private string statusCodeField;
        
        private double valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string indexDateString {
            get {
                return this.indexDateStringField;
            }
            set {
                this.indexDateStringField = value;
                this.RaisePropertyChanged("indexDateString");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public seriesKey seriesKey {
            get {
                return this.seriesKeyField;
            }
            set {
                this.seriesKeyField = value;
                this.RaisePropertyChanged("seriesKey");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string statusCode {
            get {
                return this.statusCodeField;
            }
            set {
                this.statusCodeField = value;
                this.RaisePropertyChanged("statusCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public double value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(fameNode))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(fameSeries))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://web.service.sdmx.sdms.sungard.com/")]
    public abstract partial class abstractBaseObject : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(fameSeries))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://web.service.sdmx.sdms.sungard.com/")]
    public partial class fameNode : abstractBaseObject {
        
        private string nodeLevelField;
        
        private string groupDimensionField;
        
        private string headerField;
        
        private string rootField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string nodeLevel {
            get {
                return this.nodeLevelField;
            }
            set {
                this.nodeLevelField = value;
                this.RaisePropertyChanged("nodeLevel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string groupDimension {
            get {
                return this.groupDimensionField;
            }
            set {
                this.groupDimensionField = value;
                this.RaisePropertyChanged("groupDimension");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string header {
            get {
                return this.headerField;
            }
            set {
                this.headerField = value;
                this.RaisePropertyChanged("header");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string root {
            get {
                return this.rootField;
            }
            set {
                this.rootField = value;
                this.RaisePropertyChanged("root");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SieteWSSoapChannel : WSIntegracionPlataformas.Utils.BancoCentralWS.SieteWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SieteWSSoapClient : System.ServiceModel.ClientBase<WSIntegracionPlataformas.Utils.BancoCentralWS.SieteWSSoap>, WSIntegracionPlataformas.Utils.BancoCentralWS.SieteWSSoap {
        
        public SieteWSSoapClient() {
        }
        
        public SieteWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SieteWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SieteWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SieteWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WSIntegracionPlataformas.Utils.BancoCentralWS.Respuesta SearchSeries(string user, string password, string frequencyCode) {
            return base.Channel.SearchSeries(user, password, frequencyCode);
        }
        
        public System.Threading.Tasks.Task<WSIntegracionPlataformas.Utils.BancoCentralWS.Respuesta> SearchSeriesAsync(string user, string password, string frequencyCode) {
            return base.Channel.SearchSeriesAsync(user, password, frequencyCode);
        }
        
        public WSIntegracionPlataformas.Utils.BancoCentralWS.Respuesta GetSeries(string user, string password, string firstDate, string lastDate, string[] seriesIds) {
            return base.Channel.GetSeries(user, password, firstDate, lastDate, seriesIds);
        }
        
        public System.Threading.Tasks.Task<WSIntegracionPlataformas.Utils.BancoCentralWS.Respuesta> GetSeriesAsync(string user, string password, string firstDate, string lastDate, string[] seriesIds) {
            return base.Channel.GetSeriesAsync(user, password, firstDate, lastDate, seriesIds);
        }
    }
}