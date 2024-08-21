
#include "jackdotnet.h"

jack_client_t* jackdotnet_jack_client_open_0(const char* client_name, jack_options_t options, jack_status_t* status)
{
    return jack_client_open(client_name, options, status);
}

jack_client_t* jackdotnet_jack_client_open_1(const char* client_name, jack_options_t options, jack_status_t* status,
    char* server_name)
{
    return jack_client_open(client_name, options, status, server_name);
}
