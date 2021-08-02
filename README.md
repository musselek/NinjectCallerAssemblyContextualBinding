# NinjectCallerAssemblyContextualBinding
Ninject is death, right?
It is a simple project, based od Ninject for creating a contextual binding when you work in plugin architecture and you have common or dedicated behavior for some actions
It bases on the Convention Over Configuration strategy, so if something is defined in the plugin - use it, if not - use the common one

## Example
Let's imagine the project which has three plugins
* PluginA
    * IBehavior -> PluginABehavior 
* PluginB
    * IBehavior -> PluginBBehavior 
* PluginC
and common part
* Common
    * IBehavior -> CommonBehavior

Each plugin is able to start an action.
Action method takes as an argument that should be resolved base on context. 
If a plugin has its own class which implements the behavior interface - use class from plugin, other case use the common one.

In such a situation
* PluginA - injects PluginABehavior
* PluginA - injects PluginBBehavior
* PluginC - injects CommonBehavior 
