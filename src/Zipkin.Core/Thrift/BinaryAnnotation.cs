/**
 * Autogenerated by Thrift Compiler (0.9.3)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Text;
using Thrift.Protocol;

namespace Zipkin.Thrift
{
    /// <summary>
    /// Binary annotations are tags applied to a Span to give it context. For
    /// example, a binary annotation of HTTP_PATH ("http.path") could the path
    /// to a resource in a RPC call.
    /// 
    /// Binary annotations of type STRING are always queryable, though more a
    /// historical implementation detail than a structural concern.
    /// 
    /// Binary annotations can repeat, and vary on the host. Similar to Annotation,
    /// the host indicates who logged the event. This allows you to tell the
    /// difference between the client and server side of the same key. For example,
    /// the key "http.path" might be different on the client and server side due to
    /// rewriting, like "/api/v1/myresource" vs "/myresource. Via the host field,
    /// you can see the different points of view, which often help in debugging.
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    internal sealed class BinaryAnnotation : TBase
    {
        private string _key;
        private byte[] _value;
        private AnnotationType _annotation_type;
        private Endpoint _host;

        /// <summary>
        /// Name used to lookup spans, such as "http.path" or "finagle.version".
        /// </summary>
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                __isset.key = true;
                this._key = value;
            }
        }

        /// <summary>
        /// Serialized thrift bytes, in TBinaryProtocol format.
        /// 
        /// For legacy reasons, byte order is big-endian. See THRIFT-3217.
        /// </summary>
        public byte[] Value
        {
            get
            {
                return _value;
            }
            set
            {
                __isset.@value = true;
                this._value = value;
            }
        }

        /// <summary>
        /// The thrift type of value, most often STRING.
        /// 
        /// annotation_type shouldn't vary for the same key.
        /// 
        /// <seealso cref="Zipkin.AnnotationType"/>
        /// </summary>
        public AnnotationType AnnotationType
        {
            get
            {
                return _annotation_type;
            }
            set
            {
                __isset.annotation_type = true;
                this._annotation_type = value;
            }
        }

        /// <summary>
        /// The host that recorded value, allowing query by service name or address.
        /// 
        /// There are two exceptions: when key is "ca" or "sa", this is the source or
        /// destination of an RPC. This exception allows zipkin to display network
        /// context of uninstrumented services, such as browsers or databases.
        /// </summary>
        public Endpoint Host
        {
            get
            {
                return _host;
            }
            set
            {
                __isset.host = true;
                this._host = value;
            }
        }


        internal Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        internal struct Isset
        {
            public bool key;
            public bool @value;
            public bool annotation_type;
            public bool host;
        }

        public BinaryAnnotation()
        {
        }

        public BinaryAnnotation(string key, byte[] value, AnnotationType annotationType, Endpoint host)
        {
            Key = key;
            Value = value;
            AnnotationType = annotationType;
            Host = host;
        }

        public void Read(TProtocol iprot)
        {
            iprot.IncrementRecursionDepth();
            try
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.String)
                            {
                                Key = iprot.ReadString();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 2:
                            if (field.Type == TType.String)
                            {
                                Value = iprot.ReadBinary();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 3:
                            if (field.Type == TType.I32)
                            {
                                AnnotationType = (AnnotationType)iprot.ReadI32();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 4:
                            if (field.Type == TType.Struct)
                            {
                                Host = new Endpoint();
                                Host.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }
            finally
            {
                iprot.DecrementRecursionDepth();
            }
        }

        public void Write(TProtocol oprot)
        {
            oprot.IncrementRecursionDepth();
            try
            {
                TStruct struc = new TStruct("BinaryAnnotation");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (Key != null && __isset.key)
                {
                    field.Name = "key";
                    field.Type = TType.String;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteString(Key);
                    oprot.WriteFieldEnd();
                }
                if (Value != null && __isset.@value)
                {
                    field.Name = "value";
                    field.Type = TType.String;
                    field.ID = 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(Value);
                    oprot.WriteFieldEnd();
                }
                if (__isset.annotation_type)
                {
                    field.Name = "annotation_type";
                    field.Type = TType.I32;
                    field.ID = 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32((int)AnnotationType);
                    oprot.WriteFieldEnd();
                }
                if (Host != null && __isset.host)
                {
                    field.Name = "host";
                    field.Type = TType.Struct;
                    field.ID = 4;
                    oprot.WriteFieldBegin(field);
                    Host.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }
            finally
            {
                oprot.DecrementRecursionDepth();
            }
        }

        public override string ToString()
        {
            StringBuilder __sb = new StringBuilder("BinaryAnnotation(");
            bool __first = true;
            if (Key != null && __isset.key)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Key: ");
                __sb.Append(Key);
            }
            if (Value != null && __isset.@value)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Value: ");
                __sb.Append(Value);
            }
            if (__isset.annotation_type)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Annotation_type: ");
                __sb.Append(AnnotationType);
            }
            if (Host != null && __isset.host)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Host: ");
                __sb.Append(Host == null ? "<null>" : Host.ToString());
            }
            __sb.Append(")");
            return __sb.ToString();
        }
    }
}
