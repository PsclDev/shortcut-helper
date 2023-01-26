## What is this all about?

This is a little vue3, .net project, because I wanted to control my pc more with keyboard shortcuts and trying to use the mouse less.

It contains a vue3 frontend with options api and a .net backend. The communication is via websockets and easy to configure.

Currently the backend is only working on windows, a implementation for linux wasn't done yet. I tried to port that also to macos, but there wasnt a way to get the current active window information so it can't detect any window changes and therefore a port is useless.

The backend needs a json file with a list of different apps, more about that later. Then it will check every 5 seconds the current active window and if it changes it will send the information to the frontend which then shows you the shortcuts of the new app.

## Screenshots
| Dark | Light |
| ---- | ----- |
| ![](https://shortcut-helper.pscl.dev/dark.png) | ![](https://shortcut-helper.pscl.dev/light.png) |

At the moment there isn't a automatically way or frontend configuration which can be used so the json has to be created by hand. Each App needs the following informations:
```json
{
    "WinName":"Discord.exe", //the process name, so the backend can get the shortcut list
    "Name":"Discord", // the name of the app which will be shown in the frontend
    "Shortcuts":[ // list of all shortcuts you want to display
      {
        //there is no limitation for the keys but at some point it will break the layout
        // I would not use more than four
        "Keys":[
          "ctrl",
          "tab"
        ],
        "Description":"Switch Servers"
      }
    ]
  },
```

**Json Example:**
```json
[
  {
    "WinName":"Discord.exe",
    "Name":"Discord",
    "Shortcuts":[
      {
        "Keys":[
          "ctrl",
          "tab"
        ],
        "Description":"Switch Servers"
      }
    ]
  },
  {
    "WinName":"chrome.exe",    
    "Name":"Chrome",
    "Shortcuts":[
      {
        "Keys":[
          "ctrl",
          "t"
        ],
        "Description":"Open new tab"
      },
      {
        "Keys":[
          "ctrl",
          "w"
        ],
        "Description":"Close current tab"
      },
      {
        "Keys":[
          "ctrl",
          "tab"
        ],
        "Description":"Switch tab"
      }
    ]
  }
]
```

## Required Envs:
```
// Frontend
VUE_APP_WEBSOCKET_IP
VUE_APP_WEBSOCKET_LISTENING_PATH

// Backend
PORT
LISTENING_PATH
SHORTCUTS_FILEPATH
```

## Future ideas and features
- Github Actions pipeline to build backend and provide compiled resources
- Maintenance of app data in the frontend
- Improving responsive design
- Multi backend support in the frontend, so that if several systems are available, the frontend does not have to be started several times
