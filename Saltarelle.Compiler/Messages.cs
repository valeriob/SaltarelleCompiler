﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory;

namespace Saltarelle.Compiler {
	internal static class Messages {
		private static Dictionary<int, Tuple<MessageSeverity, string>> _allMessages = new Dictionary<int, Tuple<MessageSeverity, string>> {
			{ 7001, Tuple.Create(MessageSeverity.Error, "The type {0} has both [IgnoreNamespace] and [ScriptNamespace] specified. At most one of these attributes can be specified for a type.") },
			{ 7002, Tuple.Create(MessageSeverity.Error, "{0}: The argument for [ScriptNamespace], when applied to a type, must be a valid JavaScript qualified identifier.") },
			{ 7003, Tuple.Create(MessageSeverity.Error, "The type {0} cannot have a [ResourcesAttribute] because it is not static.") },
			{ 7004, Tuple.Create(MessageSeverity.Error, "The type {0} cannot have a [ResourcesAttribute] because it is generic.") },
			{ 7005, Tuple.Create(MessageSeverity.Error, "The type {0} cannot have a [ResourcesAttribute] because it contains members that are not const fields.") },
			{ 7006, Tuple.Create(MessageSeverity.Error, "{0}: The argument for [ScriptName], when applied to a type, must be a valid JavaScript identifier.") },
			{ 7007, Tuple.Create(MessageSeverity.Error, "[IgnoreNamespace] or [ScriptNamespace] cannot be specified for the nested type {0}.") },
			{ 7008, Tuple.Create(MessageSeverity.Error, "The record type {0} must be sealed.") },
			{ 7009, Tuple.Create(MessageSeverity.Error, "The record type {0} must inherit from either System.Object or System.Record.") },
			{ 7010, Tuple.Create(MessageSeverity.Error, "The record type {0} cannot implement interfaces.") },
			{ 7011, Tuple.Create(MessageSeverity.Error, "The record type {0} cannot declare instance events.") },
			{ 7012, Tuple.Create(MessageSeverity.Error, "The type {0} must be static in order to be decorated with a [MixinAttribute]") },
			{ 7013, Tuple.Create(MessageSeverity.Error, "The type {0} can contain only methods order to be decorated with a [MixinAttribute]") },
			{ 7014, Tuple.Create(MessageSeverity.Error, "[MixinAttribute] cannot be applied to the generic type {0}.") },
			{ 7015, Tuple.Create(MessageSeverity.Error, "The type {0} must be static in order to be decorated with a [GlobalMethodsAttribute]") },
			{ 7016, Tuple.Create(MessageSeverity.Error, "The type {0} cannot have any fields, events or properties in order to be decorated with a [GlobalMethodsAttribute]") },
			{ 7017, Tuple.Create(MessageSeverity.Error, "[GlobalMethodsAttribute] cannot be applied to the generic type {0}.") },

			{ 7100, Tuple.Create(MessageSeverity.Error, "The member {0} has an [AlternateSignatureAttribute], but there is not exactly one other method with the same name that does not have that attribute.") },
			{ 7101, Tuple.Create(MessageSeverity.Error, "The name specified in the [ScriptName] attribute for member {0} must be a valid JavaScript identifier, or be blank.") },
			{ 7102, Tuple.Create(MessageSeverity.Error, "The constructor {0} cannot have an [ExpandParamsAttribute] because it does not have a parameter with the 'params' modifier.") },
			{ 7103, Tuple.Create(MessageSeverity.Error, "The inline code for the constructor {0} contained errors: {1}.") },
			{ 7104, Tuple.Create(MessageSeverity.Error, "The named specified in a [ScriptNameAttribute] for the indexer of type {0} cannot be empty.") },
			{ 7105, Tuple.Create(MessageSeverity.Error, "The named specified in a [ScriptNameAttribute] for the property {0} cannot be empty.") },
			{ 7106, Tuple.Create(MessageSeverity.Error, "Indexers cannot be decorated with [ScriptAliasAttribute].") },
			{ 7107, Tuple.Create(MessageSeverity.Error, "The property {0} cannot have a [ScriptAliasAttribute] because it is an instance member.") },
			{ 7108, Tuple.Create(MessageSeverity.Error, "The indexer cannot be decorated with [IntrinsicPropertyAttribute] because it is an interface member.") },
			{ 7109, Tuple.Create(MessageSeverity.Error, "The property {0} cannot have an [IntrinsicPropertyAttribute] because it is an interface member.") },
			{ 7110, Tuple.Create(MessageSeverity.Error, "The indexer be decorated with an [IntrinsicPropertyAttribute] because it overrides a base member.") },
			{ 7111, Tuple.Create(MessageSeverity.Error, "The property {0} cannot have an [IntrinsicPropertyAttribute] because it overrides a base member.") },
			{ 7112, Tuple.Create(MessageSeverity.Error, "The indexer cannot be decorated with an [IntrinsicPropertyAttribute] because it is overridable.") },
			{ 7113, Tuple.Create(MessageSeverity.Error, "The property {0} cannot have an [IntrinsicPropertyAttribute] because it is overridable.") },
			{ 7114, Tuple.Create(MessageSeverity.Error, "The indexer cannot be decorated with an [IntrinsicPropertyAttribute] because it implements an interface member.") },
			{ 7115, Tuple.Create(MessageSeverity.Error, "The property {0} cannot have an [IntrinsicPropertyAttribute] because it implements an interface member.") },
			{ 7116, Tuple.Create(MessageSeverity.Error, "The indexer must have exactly one parameter in order to have an [IntrinsicPropertyAttribute].") },
			{ 7117, Tuple.Create(MessageSeverity.Error, "The method {0} cannot have an [IntrinsicOperatorAttribute] because it is not an operator method.") },
			{ 7118, Tuple.Create(MessageSeverity.Error, "The [IntrinsicOperatorAttribute] cannot be applied to the operator {0} because it is a conversion operator.") },
			{ 7119, Tuple.Create(MessageSeverity.Error, "The method {0} cannot have a [ScriptSkipAttribute] because it is an interface method.") },
			{ 7120, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have a [ScriptSkipAttribute] because it overrides a base member.") },
			{ 7121, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have a [ScriptSkipAttribute] because it is overridable.") },
			{ 7122, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have a [ScriptSkipAttribute] because it implements an interface member.") },
			{ 7123, Tuple.Create(MessageSeverity.Error, "The static method {0} must have exactly one parameter in order to have a [ScriptSkipAttribute].") },
			{ 7124, Tuple.Create(MessageSeverity.Error, "The instance method {0} must have no parameters in order to have a [ScriptSkipAttribute].") },
			{ 7125, Tuple.Create(MessageSeverity.Error, "The method {0} must be static in order to have a [ScriptAliasAttribute].") },
			{ 7126, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have an [InlineCodeAttribute] because it is an interface method.") },
			{ 7127, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have an [InlineCodeAttribute] because it overrides a base member.") },
			{ 7128, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have an [InlineCodeAttribute] because it is overridable.") },
			{ 7129, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have a [InlineCodeAttribute] because it implements an interface member.") },
			{ 7130, Tuple.Create(MessageSeverity.Error, "The inline code for the method {0} contained errors: {1}.") },
			{ 7131, Tuple.Create(MessageSeverity.Error, "The method {0} cannot have an [InstanceMethodOnFirstArgumentAttribute] because it is not static.") },
			{ 7132, Tuple.Create(MessageSeverity.Error, "The [ScriptName], [PreserveName] and [PreserveCase] attributes cannot be specified on method the method {0} because it overrides a base member. Specify the attribute on the base member instead.") },
			{ 7133, Tuple.Create(MessageSeverity.Error, "The [IgnoreGenericArgumentsAttribute] attribute cannot be specified on the method {0} because it overrides a base member. Specify the attribute on the base member instead.") },
			{ 7134, Tuple.Create(MessageSeverity.Error, "The overriding member {0} cannot implement the interface method {1} because it has a different script name. Consider using explicit interface implementation.") },
			{ 7135, Tuple.Create(MessageSeverity.Error, "The [ScriptName], [PreserveName] and [PreserveCase] attributes cannot be specified on the method {0} because it implements an interface member. Specify the attribute on the interface member instead, or consider using explicit interface implementation.") },
			{ 7136, Tuple.Create(MessageSeverity.Error, "The member {0} cannot implement multiple interface methods with differing script names. Consider using explicit interface implementation.") },
			{ 7137, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have an [ExpandParamsAttribute] because it does not have a parameter with the 'params' modifier.") },
			{ 7138, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have an empty name specified in its [ScriptName] because it is an interface method.") },
			{ 7139, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have an empty name specified in its [ScriptName] because it is overridable.") },
			{ 7140, Tuple.Create(MessageSeverity.Error, "The member {0} cannot have an empty name specified in its [ScriptName] because it is static.") },
			{ 7141, Tuple.Create(MessageSeverity.Error, "The named specified in a [ScriptNameAttribute] for the event {0} cannot be empty.") },
			{ 7142, Tuple.Create(MessageSeverity.Error, "The named specified in a [ScriptNameAttribute] for the field {0} cannot be empty.") },

			{ 7500, Tuple.Create(MessageSeverity.Error, "Cannot use the type {0} in the inheritance list for type {1} because it is marked as not usable from script.") },
			{ 7501, Tuple.Create(MessageSeverity.Error, "More than one unnamed constructor for the type {0}.") },
			{ 7502, Tuple.Create(MessageSeverity.Error, "The constructor {0} must be invoked in expanded form for its its param array.") },
			{ 7503, Tuple.Create(MessageSeverity.Error, "Chaining from a normal constructor to a static method constructor is not supported.") },
			{ 7504, Tuple.Create(MessageSeverity.Error, "Chaining from a normal constructor to a constructor implemented as inline code is not supported.") },
			{ 7505, Tuple.Create(MessageSeverity.Error, "This constructor cannot be used from script.") },
			{ 7506, Tuple.Create(MessageSeverity.Error, "Property {0}, declared as being a native indexer, is not an indexer with exactly one argument.") },
			{ 7507, Tuple.Create(MessageSeverity.Error, "Cannot use the property {0} from script.") },
			{ 7508, Tuple.Create(MessageSeverity.Error, "The field {0} is constant in script and cannot be assigned to.") },
			{ 7509, Tuple.Create(MessageSeverity.Error, "The field {0} is not usable from script.") },
			{ 7510, Tuple.Create(MessageSeverity.Error, "Arrays have to be one-dimensional.") },
			{ 7511, Tuple.Create(MessageSeverity.Error, "The event {0} is not usable from script.") },
			{ 7512, Tuple.Create(MessageSeverity.Error, "The property {0} is not usable from script.") },
			{ 7513, Tuple.Create(MessageSeverity.Error, "Only locals can be passed by reference.") },
			{ 7514, Tuple.Create(MessageSeverity.Error, "The method {0} must be invoked in expanded form for its its param array.") },
			{ 7515, Tuple.Create(MessageSeverity.Error, "Cannot use the type {0} in as a generic argument to the method {1} because it is marked as not usable from script.") },
			{ 7516, Tuple.Create(MessageSeverity.Error, "The method {0} cannot be used from script.") },
			{ 7517, Tuple.Create(MessageSeverity.Error, "Cannot use the the property {0} in an anonymous object initializer.") },
			{ 7518, Tuple.Create(MessageSeverity.Error, "Cannot use the field {0} in an anonymous object initializer.") },
			{ 7519, Tuple.Create(MessageSeverity.Error, "Cannot create an instance of the type {0} because it is marked as not usable from script.") },
			{ 7520, Tuple.Create(MessageSeverity.Error, "Cannot use the type {0} in as a type argument for the class {1} because it is marked as not usable from script.") },
			{ 7521, Tuple.Create(MessageSeverity.Error, "Cannot use the variable {0} because it is an expanded param array.") },
			{ 7522, Tuple.Create(MessageSeverity.Error, "Cannot use the type {0} in a typeof expression because it is marked as not usable from script.") },
			{ 7523, Tuple.Create(MessageSeverity.Error, "Cannot perform method group conversion on {0} because it is not a normal method.") },
			{ 7524, Tuple.Create(MessageSeverity.Error, "Cannot perform method group conversion on {0} because it expands its param array in script.") },
			{ 7525, Tuple.Create(MessageSeverity.Error, "Error in inline code compilation: {0}.") },

			{ 7950, Tuple.Create(MessageSeverity.Error, "Error writing assembly: {0}.") },
			{ 7951, Tuple.Create(MessageSeverity.Error, "Error writing script: {0}.") },
			{ 7952, Tuple.Create(MessageSeverity.Error, "Error writing documentation file: {0}.") },

			{ 7999, Tuple.Create(MessageSeverity.Error, "INTERNAL ERROR: {0}. Please report this as an issue on https://github.com/erik-kallen/SaltarelleCompiler/") },
		};

		internal static Tuple<MessageSeverity, string> Get(int code) {
			Tuple<MessageSeverity, string> result;
			_allMessages.TryGetValue(code, out result);
			return result;
		}
	}
}
