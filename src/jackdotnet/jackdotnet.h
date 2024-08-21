#ifndef JACKDOTNET_H
#define JACKDOTNET_H
#include <jack/jack.h>

jack_client_t *jackdotnet_client_open_0 (const char *client_name,
    jack_options_t options,
    jack_status_t *status);

jack_client_t *jackdotnet_client_open_1 (const char *client_name,
    jack_options_t options,
    jack_status_t *status,
    char* server_name);

#endif // JACKDOTNET_H
