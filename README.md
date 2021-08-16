## What is this all about?

This is a little fun project, because I want to control the PC more with the keyboard and try to use the mouse less.

This is a small Frontend/Backend application that communicates using websockets. The Backend checks every 5 seconds which window is active on the host system (currently only Windows supported). Sends as soon as there is a new active window an info to the Frontend.

This shows all desired shortcuts of an app, these must have to be maintained manually in a JSON. 

## Future ideas and features
- Maintenance of app data in the frontend
- Improvement of the current code
- Better support of devices (for the frontend)
- Multi backend support in the frontend, so that if several systems are available, the frontend does not have to be started several times
