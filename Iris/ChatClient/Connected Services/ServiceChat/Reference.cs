﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatClient.ServiceChat {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceChat.IServiceChat", CallbackContract=typeof(ChatClient.ServiceChat.IServiceChatCallback))]
    public interface IServiceChat {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/Connect", ReplyAction="http://tempuri.org/IServiceChat/ConnectResponse")]
        int Connect(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/Connect", ReplyAction="http://tempuri.org/IServiceChat/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/Disconnect", ReplyAction="http://tempuri.org/IServiceChat/DisconnectResponse")]
        void Disconnect(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/Disconnect", ReplyAction="http://tempuri.org/IServiceChat/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/SendMessage")]
        void SendMessage(string message, int id, int chatID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string message, int id, int chatID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getUserFromList1", ReplyAction="http://tempuri.org/IServiceChat/getUserFromList1Response")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] getUserFromList1(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getUserFromList1", ReplyAction="http://tempuri.org/IServiceChat/getUserFromList1Response")]
        System.Threading.Tasks.Task<object[]> getUserFromList1Async(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getUserFromList2", ReplyAction="http://tempuri.org/IServiceChat/getUserFromList2Response")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] getUserFromList2(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getUserFromList2", ReplyAction="http://tempuri.org/IServiceChat/getUserFromList2Response")]
        System.Threading.Tasks.Task<object[]> getUserFromList2Async(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getChatFromList1", ReplyAction="http://tempuri.org/IServiceChat/getChatFromList1Response")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] getChatFromList1(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getChatFromList1", ReplyAction="http://tempuri.org/IServiceChat/getChatFromList1Response")]
        System.Threading.Tasks.Task<object[]> getChatFromList1Async(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getChatFromList2", ReplyAction="http://tempuri.org/IServiceChat/getChatFromList2Response")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] getChatFromList2(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getChatFromList2", ReplyAction="http://tempuri.org/IServiceChat/getChatFromList2Response")]
        System.Threading.Tasks.Task<object[]> getChatFromList2Async(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getUsersFromDB", ReplyAction="http://tempuri.org/IServiceChat/getUsersFromDBResponse")]
        bool getUsersFromDB();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getUsersFromDB", ReplyAction="http://tempuri.org/IServiceChat/getUsersFromDBResponse")]
        System.Threading.Tasks.Task<bool> getUsersFromDBAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/addUserToDB", ReplyAction="http://tempuri.org/IServiceChat/addUserToDBResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        bool addUserToDB(object[] user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/addUserToDB", ReplyAction="http://tempuri.org/IServiceChat/addUserToDBResponse")]
        System.Threading.Tasks.Task<bool> addUserToDBAsync(object[] user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getChatsFromDB", ReplyAction="http://tempuri.org/IServiceChat/getChatsFromDBResponse")]
        bool getChatsFromDB();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/getChatsFromDB", ReplyAction="http://tempuri.org/IServiceChat/getChatsFromDBResponse")]
        System.Threading.Tasks.Task<bool> getChatsFromDBAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/changePassword", ReplyAction="http://tempuri.org/IServiceChat/changePasswordResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        bool changePassword(object[] user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/changePassword", ReplyAction="http://tempuri.org/IServiceChat/changePasswordResponse")]
        System.Threading.Tasks.Task<bool> changePasswordAsync(object[] user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/addMessageToChat", ReplyAction="http://tempuri.org/IServiceChat/addMessageToChatResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        bool addMessageToChat(object[] message, object[] chat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/addMessageToChat", ReplyAction="http://tempuri.org/IServiceChat/addMessageToChatResponse")]
        System.Threading.Tasks.Task<bool> addMessageToChatAsync(object[] message, object[] chat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/addChatToDB", ReplyAction="http://tempuri.org/IServiceChat/addChatToDBResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        bool addChatToDB(object[] chat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/addChatToDB", ReplyAction="http://tempuri.org/IServiceChat/addChatToDBResponse")]
        System.Threading.Tasks.Task<bool> addChatToDBAsync(object[] chat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/UpdateDB", ReplyAction="http://tempuri.org/IServiceChat/UpdateDBResponse")]
        bool UpdateDB();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/UpdateDB", ReplyAction="http://tempuri.org/IServiceChat/UpdateDBResponse")]
        System.Threading.Tasks.Task<bool> UpdateDBAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChatCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/MessageCallback")]
        void MessageCallback(string message, int chatID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChatChannel : ChatClient.ServiceChat.IServiceChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceChatClient : System.ServiceModel.DuplexClientBase<ChatClient.ServiceChat.IServiceChat>, ChatClient.ServiceChat.IServiceChat {
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int Connect(string name) {
            return base.Channel.Connect(name);
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync(string name) {
            return base.Channel.ConnectAsync(name);
        }
        
        public void Disconnect(int id) {
            base.Channel.Disconnect(id);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(int id) {
            return base.Channel.DisconnectAsync(id);
        }
        
        public void SendMessage(string message, int id, int chatID) {
            base.Channel.SendMessage(message, id, chatID);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string message, int id, int chatID) {
            return base.Channel.SendMessageAsync(message, id, chatID);
        }
        
        public object[] getUserFromList1(string login) {
            return base.Channel.getUserFromList1(login);
        }
        
        public System.Threading.Tasks.Task<object[]> getUserFromList1Async(string login) {
            return base.Channel.getUserFromList1Async(login);
        }
        
        public object[] getUserFromList2(int id) {
            return base.Channel.getUserFromList2(id);
        }
        
        public System.Threading.Tasks.Task<object[]> getUserFromList2Async(int id) {
            return base.Channel.getUserFromList2Async(id);
        }
        
        public object[] getChatFromList1(int id) {
            return base.Channel.getChatFromList1(id);
        }
        
        public System.Threading.Tasks.Task<object[]> getChatFromList1Async(int id) {
            return base.Channel.getChatFromList1Async(id);
        }
        
        public object[] getChatFromList2(string name) {
            return base.Channel.getChatFromList2(name);
        }
        
        public System.Threading.Tasks.Task<object[]> getChatFromList2Async(string name) {
            return base.Channel.getChatFromList2Async(name);
        }
        
        public bool getUsersFromDB() {
            return base.Channel.getUsersFromDB();
        }
        
        public System.Threading.Tasks.Task<bool> getUsersFromDBAsync() {
            return base.Channel.getUsersFromDBAsync();
        }
        
        public bool addUserToDB(object[] user) {
            return base.Channel.addUserToDB(user);
        }
        
        public System.Threading.Tasks.Task<bool> addUserToDBAsync(object[] user) {
            return base.Channel.addUserToDBAsync(user);
        }
        
        public bool getChatsFromDB() {
            return base.Channel.getChatsFromDB();
        }
        
        public System.Threading.Tasks.Task<bool> getChatsFromDBAsync() {
            return base.Channel.getChatsFromDBAsync();
        }
        
        public bool changePassword(object[] user) {
            return base.Channel.changePassword(user);
        }
        
        public System.Threading.Tasks.Task<bool> changePasswordAsync(object[] user) {
            return base.Channel.changePasswordAsync(user);
        }
        
        public bool addMessageToChat(object[] message, object[] chat) {
            return base.Channel.addMessageToChat(message, chat);
        }
        
        public System.Threading.Tasks.Task<bool> addMessageToChatAsync(object[] message, object[] chat) {
            return base.Channel.addMessageToChatAsync(message, chat);
        }
        
        public bool addChatToDB(object[] chat) {
            return base.Channel.addChatToDB(chat);
        }
        
        public System.Threading.Tasks.Task<bool> addChatToDBAsync(object[] chat) {
            return base.Channel.addChatToDBAsync(chat);
        }
        
        public bool UpdateDB() {
            return base.Channel.UpdateDB();
        }
        
        public System.Threading.Tasks.Task<bool> UpdateDBAsync() {
            return base.Channel.UpdateDBAsync();
        }
    }
}
