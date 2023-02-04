using UnityEditor;
using UnityEngine;

namespace CodeBase.View
{
    public class GridFull
    {
        private readonly int _widthLine;

        public GridFull(int widthLine)
        {
            _widthLine = widthLine;
        }

        public static Texture2D GenerateGridTexture(Color line, Color bg) {
            Texture2D tex = new Texture2D(64, 64);
            Color[] cols = new Color[64 * 64];
            for (int y = 0; y < 64; y++) {
                for (int x = 0; x < 64; x++) {
                    Color col = bg;
                    if (y % 16 == 0 || x % 16 == 0) col = Color.Lerp(line, bg, 0.65f);
                    if (y == 63 || x == 63) col = Color.Lerp(line, bg, 0.35f);
                    cols[(y * 64) + x] = col;
                }
            }
            tex.SetPixels(cols);
            tex.wrapMode = TextureWrapMode.Repeat;
            tex.filterMode = FilterMode.Bilinear;
            tex.name = "Grid";
            tex.Apply();
            return tex;
        }
        
        public void Draw(Rect rect, Vector2 panOffset)
        {
            rect.position = Vector2.zero;

            Vector2 center = rect.size / 2f;
            Texture2D gridTex = GenerateGridTexture(Color.black, Color.clear);
           // Texture2D crossTex = graphEditor.GetSecondaryGridTexture();

            // Offset from origin in tile units
            float xOffset = -(center.x + panOffset.x) / gridTex.width;
            float yOffset = ((center.y - rect.size.y + panOffset.y)) / gridTex.height;

            Vector2 tileOffset = new Vector2(xOffset, yOffset);

            // Amount of tiles
            float tileAmountX = Mathf.Round(rect.size.x) / gridTex.width;
            float tileAmountY = Mathf.Round(rect.size.y) / gridTex.height;

            Vector2 tileAmount = new Vector2(tileAmountX, tileAmountY);
            
            GUI.DrawTextureWithTexCoords(rect, gridTex, new Rect(tileOffset, tileAmount));
        }
    }
}