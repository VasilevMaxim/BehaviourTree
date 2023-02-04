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

        public void Draw(Rect rect, Vector2 panOffset)
        {
            rect.position = Vector2.zero;

            Vector2 center = rect.size / 2f;
            Texture2D gridTex = GetGridTexture(Color.black, Color.clear);
            
            float xOffset = -(center.x) / gridTex.width;
            float yOffset = ((center.y - rect.size.y)) / gridTex.height;

            Vector2 tileOffset = new Vector2(xOffset, yOffset) + panOffset;
            
            float tileAmountX = Mathf.Round(rect.width) / gridTex.width;
            float tileAmountY = Mathf.Round(rect.height) / gridTex.height;

            Vector2 tileAmount = new Vector2(tileAmountX, tileAmountY);
            
            GUI.DrawTextureWithTexCoords(new Rect(rect.position + panOffset, rect.size), gridTex, new Rect(tileOffset, tileAmount));
        }
        
        private static Texture2D GetGridTexture(Color line, Color background) 
        {
            Texture2D texture = new Texture2D(64, 64);
            Color[] colors = new Color[64 * 64];
            
            for (int y = 0; y < 64; y++) 
            {
                for (int x = 0; x < 64; x++) 
                {
                    Color color = background;
                    if (y % 16 == 0 || x % 16 == 0) color = Color.Lerp(line, background, 0.65f);
                    if (y == 63 || x == 63) color = Color.Lerp(line, background, 0.35f);
                    colors[(y * 64) + x] = color;
                }
            }
            
            texture.SetPixels(colors);
            texture.wrapMode = TextureWrapMode.Repeat;
            texture.filterMode = FilterMode.Bilinear;
            texture.name = "Grid";
            texture.Apply();
            
            return texture;
        }
    }
}