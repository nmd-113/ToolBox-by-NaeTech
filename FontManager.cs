using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ToolBOX_by_Naetech
{
    internal class FontManager
    {
        private static PrivateFontCollection customFonts = new PrivateFontCollection();

        public static void LoadCustomFonts()
        {
            try
            {
                AddFontResource("ToolBOX.Fonts.BunkenTechSansPro-Bold.ttf");
                AddFontResource("ToolBOX.Fonts.BunkenTechSansPro-Book.ttf");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading custom fonts: {ex.Message}", "Font Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void AddFontResource(string resourcePath)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var fontStream = assembly.GetManifestResourceStream(resourcePath);

                if (fontStream == null)
                    throw new Exception($"Font resource not found: {resourcePath}");

                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);
                fontStream.Close();

                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                customFonts.AddMemoryFont(fontPtr, fontData.Length);

                uint fontsAdded = 0;
                AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref fontsAdded);

                Marshal.FreeCoTaskMem(fontPtr);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding font resource: {ex.Message}", "Font Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public static void ApplyCustomFonts(Form mainForm)
        {
            try
            {
                if (customFonts.Families.Length < 2)
                    throw new Exception("Not enough custom fonts loaded.");

                foreach (Control control in mainForm.Controls)
                {
                    if (control is Label label)
                    {
                        label.Font = new Font(customFonts.Families[1], label.Font.Size, FontStyle.Regular);
                    }
                    else if (control is Button button)
                    {
                        button.Font = new Font(customFonts.Families[0], button.Font.Size, FontStyle.Bold);
                    }
                    else if (control is CheckBox checkBox)
                    {
                        checkBox.Font = new Font(customFonts.Families[1], checkBox.Font.Size, FontStyle.Regular);
                    }

                    if (control.HasChildren)
                    {
                        ApplyCustomFontsRecursive(control);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying custom fonts: {ex.Message}", "Font Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ApplyCustomFontsRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label label)
                {
                    label.Font = new Font(customFonts.Families[1], label.Font.Size, FontStyle.Regular);
                }
                else if (control is Button button)
                {
                    button.Font = new Font(customFonts.Families[0], button.Font.Size, FontStyle.Bold);
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Font = new Font(customFonts.Families[1], checkBox.Font.Size, FontStyle.Regular);
                }

                if (control.HasChildren)
                {
                    ApplyCustomFontsRecursive(control);
                }
            }
        }
    }
}
