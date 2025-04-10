﻿using System;
using System.Text.Json.Serialization;

namespace Engine.Repositories.Flights
{
    internal record FlightDto
    {
        [JsonPropertyName("id")] public int Id { get; init; }
        [JsonPropertyName("airline")] public string Airline { get; init; } = string.Empty;
        [JsonPropertyName("from")] public string From { get; init; } = string.Empty;
        [JsonPropertyName("to")] public string To { get; init; } = string.Empty;
        [JsonPropertyName("price")] public int Price { get; init; }
        [JsonPropertyName("departure_date")] public DateOnly DepartureDate { get; init; }
    }
}