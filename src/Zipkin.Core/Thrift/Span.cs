/**
 * Autogenerated by Thrift Compiler (0.9.3)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace Zipkin.Thrift
{
    /// <summary>
    /// A trace is a series of spans (often RPC calls) which form a latency tree.
    /// 
    /// Spans are usually created by instrumentation in RPC clients or servers, but
    /// can also represent in-process activity. Annotations in spans are similar to
    /// log statements, and are sometimes created directly by application developers
    /// to indicate events of interest, such as a cache miss.
    /// 
    /// The root span is where parent_id = Nil; it usually has the longest duration
    /// in the trace.
    /// 
    /// Span identifiers are packed into i64s, but should be treated opaquely.
    /// String encoding is fixed-width lower-hex, to avoid signed interpretation.
    /// </summary>
#if SERIALIZATION
    [Serializable]
#endif
    internal sealed class Span : TBase
    {
        private long _trace_id;
        private string _name;
        private long _id;
        private long _parent_id;
        private List<Annotation> _annotations;
        private List<BinaryAnnotation> _binary_annotations;
        private bool _debug;
        private long _timestamp;
        private long _duration;

        /// <summary>
        /// Unique 8-byte identifier for a trace, set on all spans within it.
        /// </summary>
        public long TraceId
        {
            get
            {
                return _trace_id;
            }
            set
            {
                __isset.trace_id = true;
                this._trace_id = value;
            }
        }

        /// <summary>
        /// Span name in lowercase, rpc method for example. Conventionally, when the
        /// span name isn't known, name = "unknown".
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                __isset.name = true;
                this._name = value;
            }
        }

        /// <summary>
        /// Unique 8-byte identifier of this span within a trace. A span is uniquely
        /// identified in storage by (trace_id, id).
        /// </summary>
        public long Id
        {
            get
            {
                return _id;
            }
            set
            {
                __isset.id = true;
                this._id = value;
            }
        }

        /// <summary>
        /// The parent's Span.id; absent if this the root span in a trace.
        /// </summary>
        public long ParentId
        {
            get
            {
                return _parent_id;
            }
            set
            {
                __isset.parent_id = true;
                this._parent_id = value;
            }
        }

        /// <summary>
        /// Associates events that explain latency with a timestamp. Unlike log
        /// statements, annotations are often codes: for example SERVER_RECV("sr").
        /// Annotations are sorted ascending by timestamp.
        /// </summary>
        public List<Annotation> Annotations
        {
            get
            {
                return _annotations;
            }
            set
            {
                __isset.annotations = true;
                this._annotations = value;
            }
        }

        /// <summary>
        /// Tags a span with context, usually to support query or aggregation. For
        /// example, a binary annotation key could be "http.path".
        /// </summary>
        public List<BinaryAnnotation> BinaryAnnotations
        {
            get
            {
                return _binary_annotations;
            }
            set
            {
                __isset.binary_annotations = true;
                this._binary_annotations = value;
            }
        }

        /// <summary>
        /// True is a request to store this span even if it overrides sampling policy.
        /// </summary>
        public bool Debug
        {
            get
            {
                return _debug;
            }
            set
            {
                __isset.debug = true;
                this._debug = value;
            }
        }

        /// <summary>
        /// Epoch microseconds of the start of this span, absent if this an incomplete
        /// span.
        /// 
        /// This value should be set directly by instrumentation, using the most
        /// precise value possible. For example, gettimeofday or syncing nanoTime
        /// against a tick of currentTimeMillis.
        /// 
        /// For compatibilty with instrumentation that precede this field, collectors
        /// or span stores can derive this via Annotation.timestamp.
        /// For example, SERVER_RECV.timestamp or CLIENT_SEND.timestamp.
        /// 
        /// Timestamp is nullable for input only. Spans without a timestamp cannot be
        /// presented in a timeline: Span stores should not output spans missing a
        /// timestamp.
        /// 
        /// There are two known edge-cases where this could be absent: both cases
        /// exist when a collector receives a span in parts and a binary annotation
        /// precedes a timestamp. This is possible when..
        ///  - The span is in-flight (ex not yet received a timestamp)
        ///  - The span's start event was lost
        /// </summary>
        public long Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                __isset.timestamp = true;
                this._timestamp = value;
            }
        }

        /// <summary>
        /// Measurement in microseconds of the critical path, if known.
        /// 
        /// This value should be set directly, as opposed to implicitly via annotation
        /// timestamps. Doing so encourages precision decoupled from problems of
        /// clocks, such as skew or NTP updates causing time to move backwards.
        /// 
        /// For compatibility with instrumentation that precede this field, collectors
        /// or span stores can derive this by subtracting Annotation.timestamp.
        /// For example, SERVER_SEND.timestamp - SERVER_RECV.timestamp.
        /// 
        /// If this field is persisted as unset, zipkin will continue to work, except
        /// duration query support will be implementation-specific. Similarly, setting
        /// this field non-atomically is implementation-specific.
        /// 
        /// This field is i64 vs i32 to support spans longer than 35 minutes.
        /// </summary>
        public long Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                __isset.duration = true;
                this._duration = value;
            }
        }

        internal Isset __isset;
#if SERIALIZATION
        [Serializable]
#endif
        internal struct Isset
        {
            public bool trace_id;
            public bool name;
            public bool id;
            public bool parent_id;
            public bool annotations;
            public bool binary_annotations;
            public bool debug;
            public bool timestamp;
            public bool duration;
        }

        public Span()
        {
            this._annotations = new List<Annotation>(0);
            this._binary_annotations = new List<BinaryAnnotation>(0);
            this._debug = false;
            this.__isset.debug = true;
        }

        public Span(long traceId, string name, long id, long parentId, List<Annotation> annotations, List<BinaryAnnotation> binaryAnnotations, bool debug, long timestamp, long duration)
            : this()
        {
            TraceId = traceId;
            Name = name;
            Id = id;
            ParentId = parentId;
            Annotations = annotations;
            BinaryAnnotations = binaryAnnotations;
            Debug = debug;
            Timestamp = timestamp;
            Duration = duration;
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
                            if (field.Type == TType.I64)
                            {
                                TraceId = iprot.ReadI64();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 3:
                            if (field.Type == TType.String)
                            {
                                Name = iprot.ReadString();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 4:
                            if (field.Type == TType.I64)
                            {
                                Id = iprot.ReadI64();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 5:
                            if (field.Type == TType.I64)
                            {
                                ParentId = iprot.ReadI64();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 6:
                            if (field.Type == TType.List)
                            {
                                {
                                    Annotations = new List<Annotation>();
                                    TList _list0 = iprot.ReadListBegin();
                                    for (int _i1 = 0; _i1 < _list0.Count; ++_i1)
                                    {
                                        Annotation _elem2;
                                        _elem2 = new Annotation();
                                        _elem2.Read(iprot);
                                        Annotations.Add(_elem2);
                                    }
                                    iprot.ReadListEnd();
                                }
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 8:
                            if (field.Type == TType.List)
                            {
                                {
                                    BinaryAnnotations = new List<BinaryAnnotation>();
                                    TList _list3 = iprot.ReadListBegin();
                                    for (int _i4 = 0; _i4 < _list3.Count; ++_i4)
                                    {
                                        BinaryAnnotation _elem5;
                                        _elem5 = new BinaryAnnotation();
                                        _elem5.Read(iprot);
                                        BinaryAnnotations.Add(_elem5);
                                    }
                                    iprot.ReadListEnd();
                                }
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 9:
                            if (field.Type == TType.Bool)
                            {
                                Debug = iprot.ReadBool();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 10:
                            if (field.Type == TType.I64)
                            {
                                Timestamp = iprot.ReadI64();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 11:
                            if (field.Type == TType.I64)
                            {
                                Duration = iprot.ReadI64();
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
                TStruct struc = new TStruct("Span");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (__isset.trace_id)
                {
                    field.Name = "trace_id";
                    field.Type = TType.I64;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(TraceId);
                    oprot.WriteFieldEnd();
                }
                if (Name != null && __isset.name)
                {
                    field.Name = "name";
                    field.Type = TType.String;
                    field.ID = 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteString(Name);
                    oprot.WriteFieldEnd();
                }
                if (__isset.id)
                {
                    field.Name = "id";
                    field.Type = TType.I64;
                    field.ID = 4;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(Id);
                    oprot.WriteFieldEnd();
                }
                if (__isset.parent_id)
                {
                    field.Name = "parent_id";
                    field.Type = TType.I64;
                    field.ID = 5;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(ParentId);
                    oprot.WriteFieldEnd();
                }
                if (Annotations != null && __isset.annotations)
                {
                    field.Name = "annotations";
                    field.Type = TType.List;
                    field.ID = 6;
                    oprot.WriteFieldBegin(field);
                    {
                        oprot.WriteListBegin(new TList(TType.Struct, Annotations.Count));
                        foreach (Annotation _iter6 in Annotations)
                        {
                            _iter6.Write(oprot);
                        }
                        oprot.WriteListEnd();
                    }
                    oprot.WriteFieldEnd();
                }
                if (BinaryAnnotations != null && __isset.binary_annotations)
                {
                    field.Name = "binary_annotations";
                    field.Type = TType.List;
                    field.ID = 8;
                    oprot.WriteFieldBegin(field);
                    {
                        oprot.WriteListBegin(new TList(TType.Struct, BinaryAnnotations.Count));
                        foreach (BinaryAnnotation _iter7 in BinaryAnnotations)
                        {
                            _iter7.Write(oprot);
                        }
                        oprot.WriteListEnd();
                    }
                    oprot.WriteFieldEnd();
                }
                if (__isset.debug)
                {
                    field.Name = "debug";
                    field.Type = TType.Bool;
                    field.ID = 9;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBool(Debug);
                    oprot.WriteFieldEnd();
                }
                if (__isset.timestamp)
                {
                    field.Name = "timestamp";
                    field.Type = TType.I64;
                    field.ID = 10;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(Timestamp);
                    oprot.WriteFieldEnd();
                }
                if (__isset.duration)
                {
                    field.Name = "duration";
                    field.Type = TType.I64;
                    field.ID = 11;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(Duration);
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
            StringBuilder __sb = new StringBuilder("Span(");
            bool __first = true;
            if (__isset.trace_id)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Trace_id: ");
                __sb.Append(TraceId);
            }
            if (Name != null && __isset.name)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Name: ");
                __sb.Append(Name);
            }
            if (__isset.id)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("TraceId: ");
                __sb.Append(Id);
            }
            if (__isset.parent_id)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Parent_id: ");
                __sb.Append(ParentId);
            }
            if (Annotations != null && __isset.annotations)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Annotations: ");
                __sb.Append(Annotations);
            }
            if (BinaryAnnotations != null && __isset.binary_annotations)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Binary_annotations: ");
                __sb.Append(BinaryAnnotations);
            }
            if (__isset.debug)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Debug: ");
                __sb.Append(Debug);
            }
            if (__isset.timestamp)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Timestamp: ");
                __sb.Append(Timestamp);
            }
            if (__isset.duration)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Duration: ");
                __sb.Append(Duration);
            }
            __sb.Append(")");
            return __sb.ToString();
        }
    }
}