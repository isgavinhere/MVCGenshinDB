using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GenshinDB.Data;
using System;
using System.Linq;

namespace GenshinDB.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GenshinDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GenshinDBContext>>()))
            {
                // Look for any movies.
                if (context.Artifact.Any())
                {
                    return;   // DB has been seeded
                }

                context.Artifact.AddRange(
                    new Artifact
                    {
                        Name = "Retracing Bollide",
                        Rarity = 5,
                        SetEffect2 = "Increases Shield Strength by 35%",
                        SetEffect4 = "While protected by a shield, gain an additional 40% Normal and Charged Attack DMG.",
                        Description = "A man-made flower in eternal bloom. Who knows if there truly is life in there?",
                        FullDescription = "A man-made flower in eternal bloom. Who knows if there truly is life in there?\n\nA summer festival flower that blooms forever,\nThat will not wilt even if buried deep below the snow.\n\nSome may label it an imitation, a false life,\nFor life lies in change, pain and growth,\nIn meetings, and also in partings.\n\nBut the memories of meeting her,\nOf watching the fireworks bloom in the sky like fresh flowers together,\nThe memories of that foxy-eyed woman who eventually disappeared without a trace...\nThat unwithering flower is the final thing to remember her by.\n\nIn the end, the difference comes down to the fact that for some,\nLife is as eternal as this undying summer bloom,\nBut for most, it is as transient as smoke."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
