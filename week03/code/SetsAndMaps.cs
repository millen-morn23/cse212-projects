
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
            {
                continue;
            }

            string reversed = $"{word[1]}{word[0]}";

            if (wordSet.Contains(reversed) &&
                string.CompareOrdinal(word, reversed) < 0)
            {
                pairs.Add($"{word} & {reversed}");
            }
        }

        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string first = word1.Replace(" ", "").ToUpperInvariant();
        string second = word2.Replace(" ", "").ToUpperInvariant();

        if (first.Length != second.Length)
        {
            return false;
        }

        var letterCounts = new Dictionary<char, int>();

        foreach (char letter in first)
        {
            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts[letter] = 1;
            }
        }

        foreach (char letter in second)
        {
            if (!letterCounts.ContainsKey(letter))
            {
                return false;
            }

            letterCounts[letter]--;

            if (letterCounts[letter] < 0)
            {
                return false;
            }
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var response = client.GetAsync(uri).GetAwaiter().GetResult();
        response.EnsureSuccessStatusCode();

        var json = response.Content.ReadAsStringAsync()
            .GetAwaiter().GetResult();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.Features == null)
        {
            return [];
        }

        var summaries = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            var properties = feature.Properties;

            if (properties?.Place == null || properties.Mag == null)
            {
                continue;
            }

            summaries.Add(
                $"{properties.Place} - Mag {properties.Mag.Value}");
        }

        return summaries.ToArray();
    }
}
