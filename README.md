# ApplicationLauncher #

ApplicationLauncher is a simple, locked down Win32 shell replacement.  It's designed for an environment where you have a "gallery" of applications.

It doesn't do any lock down on the applications themselves, so you'll probably want to implement Group Policies (or other restrictions) to prevent access to things like the save and open dialogues (because they can be used to start Explorer) or Windows Help.

I originally wrote this software back in 2007 for a retro-gaming display.  Unfortunately the event that it was being hosted massively cut back on the scope of their events due to a forced venue change, so it didn't end up getting used for the event.

I updated it in August 2008 with some new features and Windows 98 support for a retro-gaming event that StreetGeek ran.  I locked down the machines by actually deleting programs that weren't needed (Windows 98 let you do this).  Since then the event moved on to different hardware and a completely different system setup (which allowed the luxury of giving complete access to the system and relying on storage virtualisation to protect it), and I didn't really think of using this software again.  They've since moved on to another setup again since my departure from the event.

I haven't touched the software in a very long time.  I've decided to release it as open source software in the hope someone will find it useful.  I've fixed some issues with it more recently and added some extra configuration options and documentation.  The majority of it is still in the state I left it in 2008.

The software is fairly flexible in how you can set it up -- it is my goal that you should be able to change the majority of the UI theme from the configuration file.

There's some example configuration files in the `examples` directory, as well as batch scripts to start it up.

It includes a copy of Nini (a .NET configuration parser library), which is very useful (really, something that should have been a part of .NET...).  I've cut it down quite a bit (it only supports reading INI files now) to save space in the resulting binaries.