Stops a hidden base game bug from crashing cities with many road intersections.

# What does it fix?
Cities: Skylines II has a bug in the base game that can crash it to desktop once a city has a lot of road intersections, for example several large road grids.

The game reserves room in memory for the data it uses to shape the terrain under your roads. It decides how much room to reserve with a simple rule: count the roads and assume each one needs 6 pieces of data. That works for a road between two simple bends, but every intersection adds extra pieces. A road with an intersection at both ends needs 10, not 6.

When the reserved room runs out, the game doesn't notice. It keeps writing anyway and damages whatever happens to sit next to it in memory. Nothing happens right away, which is what makes this bug so hard to catch. The game crashes a little later, in some completely unrelated place, usually while rendering.

# Does it affect me?
It can affect anyone, with or without mods:
- **It's not your hardware.** RAM, GPU or CPU make no difference. A high end PC crashes at exactly the same point as a low end one.
- **It's not your road type.** Small streets and 8 lane avenues behave exactly the same. What matters is how many of your roads end in intersections.
- **Grid cities are hit the hardest,** because almost every road ends in an intersection there.

**Typical symptoms:**
- The game crashes to desktop without an error window after you build a lot of roads, often while you're just moving the camera around.
- The crash seems random, and crash logs point to a different place every time.
- A large, grid heavy city may even crash while loading, or shortly after.

# How does it work?
The fix changes one single number: the game now reserves room for 12 pieces per road instead of 6. That covers even a city built entirely from intersections, with room to spare. Nothing else in the game is changed.

**Tested:** In one session I placed 41 large 10x10 road grids with the fix enabled, without a single crash. In that same session the base game would have run out of room 24 times, writing up to 3.5 MB of data where it didn't belong.

# Is it safe?
- **Your save files are not affected.** This data is never stored in your save. The game rebuilds it every time a city is loaded.
- **You can add or remove the mod at any time,** even in the middle of an existing city. Removing it only brings the original bug back.
- **Very small memory cost.** A few extra MB in most cities, and around 10 MB more than the base game even in a very large grid city.
- **No performance impact.** It changes a number, not how the game works.

# Compatibility
- **Mert's ToolBox** already includes this fix. You can use both mods together without any problem. The fix is applied only once, whichever mod loads first.
- **Game updates:** If the developers fix this in the game itself, the mod notices and simply stays out of the way. If the game code changes, it leaves the game untouched instead of guessing.
- It should work with all other mods, since it only touches this one number.

# Disclaimer
This mod fixes one specific crash. Cities: Skylines II can still crash for other reasons, such as broken assets, mod conflicts or running out of memory. If you still get crashes with this mod installed, they come from something else.

The issue has been reported to the developers, together with a full technical analysis. I hope it gets fixed in the game itself soon, and then this mod won't be needed anymore.

# For the technically curious
TerrainSystem.CullForCascades sizes its lane cull list as road count x 6 (plus 25%), and CullRoadsJob fills it with AddNoResize, which has no capacity check in the release build. Junction edges produce 10 lane sections, and tunnel or lowered road transitions can produce more. NativeList rounds the capacity up to a power of two, which is why the overflow comes and goes as the city grows. The mod uses a Harmony transpiler to change the factor from 6 to 12, and it leaves the method untouched if the factor is already 10 or higher.

# Bug Reporting
Please include this information with your feedback:
1. When does it happen? (During gameplay, during save, during load, during exit, etc.)
1. Which other mods are you using?
1. Is there an exception window? What does it say? Please copy and paste the message.

# Community & Feedback
**Official Discussion Hub:** Please join the conversation and share your feedback on my official Paradox Plaza forum thread.
**Where to reach me:**
- **Reddit:** Post your screenshots or feedback on r/CitiesSkylines and tag me or send a DM to ***/u/EmotionalCourse6266***
- **Direct:** flashbond@gmail.com
