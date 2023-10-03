using ICities;
using ColossalFramework.UI;
using UnityEngine;

namespace ClearGarbage
{
    public class ClearGarbageLoading : LoadingExtensionBase
    {
        private UIButton _clearGarbageButton;

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (_clearGarbageButton != null) return;

            CityServiceWorldInfoPanel panel = UIView.library.Get<CityServiceWorldInfoPanel>(typeof(CityServiceWorldInfoPanel).Name);
            UIButton button = panel.component.AddUIComponent<UIButton>();

            button.size = new Vector2(130f, 27f);
            button.textScale = 0.9f;
            button.normalBgSprite = "ButtonMenu";
            button.hoveredBgSprite = "ButtonMenuHovered";
            button.pressedBgSprite = "ButtonMenuPressed";
            button.disabledBgSprite = "ButtonMenuDisabled";
            button.disabledTextColor = new Color32(128, 128, 128, 255);
            button.canFocus = false;

            button.name = "ClearGarbage";
            button.text = "Clean Garbage";

            button.relativePosition = new Vector3(160f, 270f);

            _clearGarbageButton = button;

            button.eventClicked += (c, p) =>
            {
                ushort buildingId = WorldInfoPanel.GetCurrentInstanceID().Building;

                CleanGarbage(buildingId);
            };
        }

        private void CleanGarbage(ushort buildingId)
        {
            BuildingManager.instance.m_buildings.m_buffer[buildingId].m_garbageBuffer = 0;
        }
    }
}
