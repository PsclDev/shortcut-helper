## What is this all about?

This is a little fun project, because I wanted to control my pc more with the keyboard and shortcuts and trying to use the mouse less.

It contains a vue3 frontend with options api and two backends, one is used for windows and the other for backend. It is designed to support more os in the future.

The Backend hols a json array with shortcuts for applications, every 5 seconds it will be checked which window is active and then send the shortcuts for the specific application to the frontend.

Currently the json file has to be manually filled and updated.

**Json Example:**
```json
[
  {
    "MacName": "Discord",
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
    "MacName": "Google Chrome",
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

**Required Envs:**
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
- Better support of devices (for the frontend)
- Multi backend support in the frontend, so that if several systems are available, the frontend does not have to be started several times
